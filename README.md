# 8085 MicroSim

An 8085 microprocessor simulator with a web-based interface. This project provides a comprehensive simulation of the Intel 8085 microprocessor, allowing users to write, execute, and debug 8085 assembly programs.

## Features

- Complete 8085 instruction set implementation
- Register operations and flag handling
- Stack operations
- Arithmetic and logical operations
- Data transfer operations
- Branching and control flow
- Web-based user interface for easy interaction

## Project Structure

- `ALU.cs` - Arithmetic Logic Unit implementation
- `CStack.cs` - Stack operations implementation
- `DataTransfer.cs` - Data transfer instructions
- `Decode.cs` - Instruction decoder
- `Flags.cs` - Status flags handling
- `HexCodes.cs` - Hexadecimal operation codes
- `InstructionSet.cs` - Complete 8085 instruction set
- `Register.cs` - Register operations
- `Rotate.cs` - Rotation instructions
- `Branching.cs` - Branching and jump instructions
- `frontend/` - Web interface files (HTML, CSS, JavaScript)

## Prerequisites

- .NET 6.0 SDK or later
- A modern web browser

## Getting Started

1. Clone the repository
2. Navigate to the project directory
3. Build the project:
```powershell
dotnet build
```
4. Run the application:
```powershell
dotnet run
```
5. Open your web browser and navigate to the URL shown in the console.

## Usage

1. Write your 8085 assembly code in the web interface
2. Use the simulator controls to:
   - Execute instructions step by step
   - View register contents
   - Monitor flag status
   - Inspect memory contents
   - Debug your program

## API Endpoints

The project includes a REST API for programmatic interaction with the simulator. API documentation is available through Swagger UI when running the application.

## Development

The project uses:
- ASP.NET Core 6.0 for the backend
- Swagger/OpenAPI for API documentation
- HTML/CSS/JavaScript for the frontend interface