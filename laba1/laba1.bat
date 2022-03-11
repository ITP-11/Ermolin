@echo off
cls
:start
echo Vvedite zadannoe rasshirenie
set /p r1=""

For /R D:\OC\1 %%i In ("%r1%") Do (
    If Exist %%i (
        copy %%i "D:\OC\2"
    )
)
pause