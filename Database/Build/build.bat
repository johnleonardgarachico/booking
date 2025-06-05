@echo off

:: Set default values if parameters are not provided
SET Environment=%1
IF "%Environment%"=="" SET Environment=development

IF "%Environment%"=="development" (
    sqlcmd -S localhost -E -i Databases.sql
    sqlcmd -S localhost -E -i Schemas.sql
    sqlcmd -S localhost -E -i Tables.sql
    sqlcmd -S localhost -E -i StoredProcedures\AddUser.sql
    sqlcmd -S localhost -E -i StoredProcedures\DeleteUser.sql
    sqlcmd -S localhost -E -i StoredProcedures\GetUser.sql
    sqlcmd -S localhost -E -i StoredProcedures\UpdateUser.sql
    echo All scripts executed successfully.
    exit /b
)

:: Not yet Supported Prompt (Will remove as needed)
echo Other Environment is not yet supported! Check Username and Password handling.
exit /b

:: Check if Environment is valid (testing OR production)
IF NOT "%Environment%"=="testing" IF NOT "%Environment%"=="production" (
    echo Invalid Environment!
    exit /b
)
:: Check if ServerName parameter is missing
IF "%2"=="" (
    echo Missing ServerName parameter!
    exit /b
)
:: Check if DatabaseName parameter is missing
IF "%3"=="" (
    echo Missing DatabaseName parameter!
    exit /b
)

SET ServerName=%2
SET DatabaseName=%3

sqlcmd -S %2 -U <Username> -P <Password> -i Databases.sql
sqlcmd -S %2 -U <Username> -P <Password> -d Booking -i Schemas.sql
sqlcmd -S %2 -U <Username> -P <Password> -d Booking -i Tables.sql
echo All scripts executed successfully.
pause
