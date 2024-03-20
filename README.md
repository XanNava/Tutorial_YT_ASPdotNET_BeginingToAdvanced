# YT_ASPdotNET_BeginingToAdvanced
https://www.youtube.com/watch?v=6SAFgcMie4U&ab_channel=freeCodeCamp.org

Section: Create Model - Create Context

Not on the design of the DB Context. We seperate the relationship of Ingredients and Dish with the DishIngredients class.
Initially using just the object reference as the key(seeing what is created in the DB for this, assuming it will see the setup Key in the Dish and Ingredient).

Section: Connecting the Project to the Database

Had to install SQL Server and SQL Server Management Studio.
https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16#download-ssms

Had to set the encryption on the connection to allow untrusted cert.
https://stackoverflow.com/questions/17615260/the-certificate-chain-was-issued-by-an-authority-that-is-not-trusted-when-conn

On command
```Add-Migration "Initial migration"```
Unable to create a 'DbContext' of type ''. The exception 'The property or navigation 'Dish' cannot be added to the 'DishIngredient' type because a property or navigation with the same name already exists on the 'DishIngredient' type.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
