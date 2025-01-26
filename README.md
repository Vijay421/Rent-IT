# Rent-IT
Vehicle rental through the Rent-IT web application.

## Setup

### Backend

Step 1: Create the db in ssms and name it: `Rent-IT` 

Step 2: Copy `local_config.dist.json` to `local_config.json`.

> [!WARNING]
> **Do not** delete the `local_config.dist.json` file!

Step 3: Replace `data source` value with the server name and `catalog` value with database name

Step 4: Create the database with: `dotnet ef database update`. It should create the identity tables in the db.

Step 5: Run the project through your IDE.

### Frontend

Step 1: Install the packages with `npm install`

Step 2: To launch the frontend in dev mode use `npm run dev`
