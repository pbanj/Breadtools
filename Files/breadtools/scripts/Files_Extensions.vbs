FileExtension = "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\HideFileExt"
Set Command1 = WScript.CreateObject("WScript.Shell")
Check = Command1.RegRead(FileExtension)
If Check = 1 Then
Command1.RegWrite FileExtension, 0, "REG_DWORD"
Else
Command1.RegWrite FileExtension, 1, "REG_DWORD"
End If
Command1.SendKeys "{F5}"