# Rent-IT
This repository contains the school project CarAndAll, which took place in semester 3.

Students:
- Chris Aartman (23081872)
- Mick Hoogendijk (23053194)
- Shendrick Williams (23011580)
- Vijay Sankar (19025661)

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

Step 1: Install the packages use `npm install`

Step 2: Iaunch the frontend in dev mode use `npm run dev`

[Work in progress.]

## Use swagger with authorizations

This [video](https://youtu.be/8J3nuUegtL4?si=ljkSM-gqVgWBbSYJ&t=1099) has been used to make authorizations possible with Swagger.

> [!IMPORTANT]
> Besure to add 'Bearer' in front of the token, when filling in the token in Swagger. Like so 'Bearer [insert token here!]'.
