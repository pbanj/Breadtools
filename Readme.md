This will install a menu to your context(right click) menu.  
items include regedit, open cmd here(normal and admin) show/hide known file types, show/hide hidden files/folders, open bash here, open admin powershell here, and open powershell here.

**Newest ver may only work fully on windows 10 with the creators update.**
here is an older ver that will work on windows 8/8.1 and should work on 7: [Tools_menu.zip](https://cdn.discordapp.com/attachments/246402376099954689/288882232892981249/Tools_Menu.zip)


**HOW TO USE:**

1. Run Tools.bat as admin
2. Follow what it says
3. If icons dont show up reboot or restart explorer


if you would like take ownership in your context menu you will find it in the "take ownership" folder. 



**Changelog:**

- v0.2 - added open powershell as admin here, fixed open cmd as admin here, no longer need ele.exe and the e.cmd file

- v0.3 - able to remove the restart explorer.bat file thanks to coldbloc

- v0.4 - added power menu. normal has lock, logoff, restart, restart with boot options, and shut down. the second has all of the first but sleep, hibernate, and switch user.

- v0.5 - fixed an issue in the hidden files vbs(thanks LEDelete for pointing it out), fixed missing icon folder copy command in install script (thanks trm96 for pointing that out) should fix icons not showing up

- V0.6 - fixed missing power menu icons again.

- V0.7 - fixed broken "Admin Cmd Here" for windows 10(thanks microsoft -_-), and added  "powershell here" for opening powershell in the current directory.

- v0.8 - added open bash here. take note that you must [enable the linux subsystem](https://msdn.microsoft.com/en-us/commandline/wsl/install_guide) for this to work.

- v0.9 - removed the need to open cmd first to open bash. take note that you must [enable the linux subsystem](https://msdn.microsoft.com/en-us/commandline/wsl/install_guide) for this to work.

- v1.0 - fixed bash not opening, made bash optional for those that don't want it.

- v1.1 - fixed admin cmd not working for some people

**what the tool menu looks like**


![Tools](https://i.imgur.com/KiXfu3Q.png)


**what the power menu looks like with all options**


![Power](http://i.imgur.com/d7gK35h.png)
