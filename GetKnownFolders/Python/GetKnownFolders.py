from win32com.shell import shell, shellcon
print shell.SHGetFolderPath(0, shellcon.CSIDL_MYPICTURES, None, 0)
print shell.SHGetFolderPath(0, shellcon.CSIDL_PERSONAL, None, 0)

