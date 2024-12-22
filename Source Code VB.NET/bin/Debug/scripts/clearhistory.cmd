TITLE Alin Kahn's Anti-NSFW History Cleaner

@echo Killing Browser processes
taskkill /f /im firefox.exe
taskkill /f /im chrome.exe
taskkill /f /im r3dfox.exe

@echo Deleting History from all browsers
del "C:\Users\%username%\AppData\Local\Supermium\User Data\Default\History*" /q /f /s
set ChromeDir=C:\Users\%USERNAME%\AppData\Local\Google\Chrome\User Data
del /q /s /f “%ChromeDir%”
rd /s /q “%ChromeDir%”
set DataDir=C:\Users\%USERNAME%\AppData\Local\Mozilla\Firefox\Profiles
del /q /s /f “%DataDir%”
rd /s /q “%DataDir%”
for /d %%x in (C:\Users\%USERNAME%\AppData\Roaming\Mozilla\Firefox\Profiles\*) do del /q /s /f %%x\*sqlite