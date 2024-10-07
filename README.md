# Platform Demo

## Test Task to Complete

### Overview
This repository contains a .NET solution named **PlatformDemo**. The solution includes two projects: a .NET 8 Class Library and an ASP.NET Core 8 Web Application. The primary purpose of this solution is to manage Service Plans and Timesheets.

### Repository Information
- **GitHub Repository Name**: `platform_demo_024`
- **Email for Submission**: recruiting@logicimtech.com

## .NET Solution Details

### 1. .NET 8 Class Library
- Contains one Entity Framework `DbContext` using LocalDB.
- Manages two main entities:
  - **ServicePlan**: 
    - Properties:
      - `ServicePlanId` (Primary Key)
      - `DateOfPurchase` (Date of purchase)
  - **Timesheet**:
    - Properties:
      - `TimesheetId` (Primary Key)
      - `ServicePlanId` (Foreign Key related to ServicePlan)
      - `StartTime` (Date and time of start)
      - `EndTime` (Date and time of end)
      - `Description` (Description of the timesheet)
- A Service Plan can have zero or more Timesheets associated with it.

### 2. ASP.NET Core 8 Web App
- References the Class Library and builds a page that displays:
  - A list of Service Plans with their date of purchase.
  - The number of associated Timesheets for each Service Plan.
- Each Service Plan is displayed on a single line, even if it has no related Timesheets.
- The application seeds sample data with:
  - 10-15 Service Plans.
  - 0-5 Timesheets per Service Plan.

## Additional Instructions

- **Readme.md**: This file includes the content of the task description as required.
- **Code Documentation**: All code is documented with proper comments explaining the logic and decisions made.
- **Customization**: The final solution includes additional features or enhancements that showcase my capabilities. This could be either visual (UI improvements) or functional (extra features).
- **Judgment Calls**: Any decisions made regarding unspecified aspects of the task are documented in the code comments to provide clarity on the reasoning behind them.

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server LocalDB

### Setup Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/platform_demo_024.git
