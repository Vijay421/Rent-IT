# Rent-IT
This repository contains the school project CarAndAll, which took place in semester 3.

Students:
- Chris Aartman (23081872)
- Mick Hoogendijk (23053194)
- Shendrick Williams (23011580)
- Vijay Sankar (19025661)

## Setup

### Backend

Step 1: copy `local_config.dist.json` to `local_config.json` and fill in the database url.

> [!WARNING]
> **Do not** delete the `local_config.dist.json` file!

Step 2: create the db in ssms and name it: `Rent-IT` 

Step 3: create the database with: `dotnet ef database update`. It should create the identity tables in the db.

Step 4: run the project through your IDE.

### Frontend

Step 1: install the packages use `npm install`

Step 2: launch the frontend in dev mode use `npm run dev`

[Work in progress.]
