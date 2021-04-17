

Instructions for Leanheat.Identity.Api

SETUP:
1. Create SQL Database using - SQL Server Onbject Explorer - in Visual Studio  - with the name "LeanheatIdentityDB"

2. Open the DB and click properties than copy the -  Data Source -
Ex. of Data source  --> Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LeanheatIdentityDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

3. Update the DB by using the - Package Manager Console - with the latest migration from the migration folder
Ex. Update-Database -migration PropertyUpdateNew

4. Set the Identity to Startup project if its not already
