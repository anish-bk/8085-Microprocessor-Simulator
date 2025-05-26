const state = {
registers: { A:'00', B:'00', C:'00', D:'00', E:'00', H:'00', L:'00', PC:'2000', SP:'FFFF' },
flags:     { S:'0', Z:'0', AC:'0', P:'0', CY:'0' },
memory:    {},
program:   [],
currentInstruction: null,
status: 'Ready to execute program'
};

// Initialize 256 bytes of memory starting at 0x2000
function initializeMemory() {
for (let i = 0; i < 256; i++) {
const addr = (0x2000 + i).toString(16).toUpperCase().padStart(4,'0');
state.memory[addr] = '00';
}
renderMemory();
}

function renderMemory() {
const tbody = document.getElementById('memoryTable');
if (!tbody) return; tbody.innerHTML='';
for (let row=0; row<16; row++) {
const tr=document.createElement('tr');
const base=0x2000+row*16;
const addrCell=document.createElement('td');
addrCell.className='px-4 py-2 memory-address';
addrCell.textContent=base.toString(16).toUpperCase().padStart(4,'0');
tr.appendChild(addrCell);
for (let col=0; col<16; col++) {
const a=(base+col).toString(16).toUpperCase().padStart(4,'0');
const td=document.createElement('td');
td.className='px-2 py-1 memory-cell text-center';
td.textContent=state.memory[a]||'00'; td.dataset.address=a;
tr.appendChild(td);
}
tbody.appendChild(tr);
}
}

function updateRegisters() {
for (const r in state.registers) {
const el=document.getElementById(r);
if (el) el.querySelector('div:last-child').textContent=state.registers[r];
}
}

function updateFlags() {
for (const f in state.flags) {
const el=document.getElementById(f);
if (el) el.querySelector('div:last-child').textContent=state.flags[f];
}
}

function updateStatus() {
document.getElementById('statusMessage').textContent=state.status;
}

function highlightActiveComponents() {
document.querySelectorAll('.register, .flag, .memory-cell, .code-line, .memory-address')
.forEach(el=>el.classList.remove('active','pulse'));
if (state.currentInstruction) {
const lines=document.querySelectorAll('.code-line');
const i=state.currentInstruction.line;
if (lines[i]) lines[i].classList.add('active');
}
// PC highlight
document.querySelectorAll('.memory-cell').forEach(td=>{
if (td.dataset.address===state.registers.PC) td.classList.add('active','pulse');
});
// HL pair
const hl=(parseInt(state.registers.H,16)*256+parseInt(state.registers.L,16))
.toString(16).padStart(4,'0').toUpperCase();
document.querySelectorAll('.memory-cell').forEach(td=>{
if (td.dataset.address===hl) td.classList.add('active');
});
}

// Decode hex to mnemonic
function decodeMnemonic(hex) {
const map={ '3E':'MVI A,','06':'MVI B,','0E':'MVI C,','16':'MVI D,','1E':'MVI E,','26':'MVI H,','2E':'MVI L,','36':'MVI M,','80':'ADD B','81':'ADD C','82':'ADD D','83':'ADD E','84':'ADD H','85':'ADD L','86':'ADD M','87':'ADD A','90':'SUB B','91':'SUB C','92':'SUB D','93':'SUB E','94':'SUB H','95':'SUB L','96':'SUB M','97':'SUB A','C3':'JMP','CD':'CALL','C9':'RET','76':'HLT' };
return map[hex]||'Unknown';
}

// Event wiring
window.addEventListener('DOMContentLoaded',()=>{
initializeMemory(); updateRegisters(); updateFlags(); updateStatus();
document.getElementById('addRowBtn').addEventListener('click',()=>{
const tbody=document.getElementById('codeTable');
const rows=tbody.querySelectorAll('tr');
const last=rows[rows.length-1];
const next=(parseInt(last.querySelector('.memory-address').textContent,16)+1)
.toString(16).toUpperCase().padStart(4,'0');
const tr=document.createElement('tr'); tr.className='code-line';
tr.innerHTML = `<td class="memory-address">${next}</td>
                <td><input class="hex-code input w-16"/></td>
                <td class="mnemonic">-</td>`;tbody.appendChild(tr);
});
document.addEventListener('input',e=>{
if (e.target.classList.contains('hex-code')) {
const v=e.target.value.toUpperCase();
if (/^[0-9A-F]{2}$/.test(v)) {
const row=e.target.closest('tr');
row.querySelector('.mnemonic').textContent=decodeMnemonic(v);
const rows=document.getElementById('codeTable').querySelectorAll('tr');
if (row===rows[rows.length-1]) document.getElementById('addRowBtn').click();
}
}
});
document.getElementById('runBtn').addEventListener('click',()=>{
state.program=[];
document.querySelectorAll('#codeTable tr').forEach((row,i)=>{
const addr=row.querySelector('.memory-address').textContent;
const hex=row.querySelector('.hex-code').value.toUpperCase();
if (hex) {
state.program.push({ address:addr, hex, mnemonic:row.querySelector('.mnemonic').textContent, line:i });
state.memory[addr]=hex;
}
});
if (!state.program.length) return;
state.currentInstruction={ line:0 };
state.registers.PC=state.program[0].address;
simulateApiCall();
});
document.getElementById('stepBtn').addEventListener('click',()=>{
if (!state.program.length) return alert('Run program first');
if (state.currentInstruction.line<state.program.length-1) {
state.currentInstruction.line++;
state.registers.PC=state.program[state.currentInstruction.line].address;
simulateInstructionExecution();
updateRegisters(); updateFlags(); updateStatus(); highlightActiveComponents();
} else { state.status='Execution complete'; updateStatus(); }
});
document.getElementById('resetBtn').addEventListener('click',()=>location.reload());
});

function simulateApiCall() {
    state.status = 'Executing...';
    updateStatus();
  
    // Build hex string (e.g., "3E00C3...")
    const programHex = state.program.map(instr => instr.hex).join('');
  
    // Prepare payload as per .NET backend's expectation
    const payload = {
      Name: [programHex]  // The .NET backend reads Name[1] or Name[0]
    };
  
    fetch('/api/TodoApp/AddNotes', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(payload)
    })
    .then(res => res.json())
    .then(data => {
      // Update frontend state from backend response
      state.registers.A = data.A;
      state.registers.B = data.B;
      state.registers.C = data.C;
      state.registers.D = data.D;
      state.registers.E = data.E;
      state.registers.H = data.H;
      state.registers.L = data.L;
      state.flags.S = data.S;
      state.flags.Z = data.Z;
      state.flags.AC = data.AC;
      state.flags.P = data.P;
      state.flags.CY = data.CY;
      state.registers.SP = data.SP;
  
      // Optional: mark address where first opcode resides (optional)
      if (data.d) {
        state.registers.PC = '2000'; // or wherever your PC should start from
      }
  
      updateRegisters();
      updateFlags();
      updateStatus();
      highlightActiveComponents();
      renderMemory();
  
      state.status = 'Execution complete';
      updateStatus();
    })
    .catch(err => {
      console.error('API call failed:', err);
      state.status = 'Error during execution';
      updateStatus();
    });
  }
  

function simulateInstructionExecution() {
const instr=state.program[state.currentInstruction.line];
switch(instr.hex) {
case '3E': state.registers.A='FF'; break;
case '80': {
const sum=parseInt(state.registers.A,16)+parseInt(state.registers.B,16);
state.registers.A=(sum%256).toString(16).padStart(2,'0').toUpperCase();
state.flags.Z=state.registers.A==='00'?'1':'0';
state.flags.CY=sum>255?'1':'0';
break;
}
case 'C3': state.registers.PC=state.program[state.currentInstruction.line+1]?.address||state.registers.PC; break;
default: break;
}
state.memory[instr.address]=instr.hex;
}

