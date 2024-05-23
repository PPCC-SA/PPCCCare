Public Class StatSupport
    Private sStat As String
    Public Property StatSupport() As String
        Get
            Return sStat
        End Get
        Set(ByVal Stat As String)
            Select Case Stat
                Case "C"
                    sStat = "Closed"
                Case "D"
                    sStat = "Identify"
                Case "F"
                    sStat = "Awaiting Infor"
                Case "H"
                    sStat = "Hold"
                Case "I"
                    sStat = "In-Process"
                Case "L"
                    sStat = "Move to LIV"
                Case "M"
                    sStat = "Monitor"
                Case "O"
                    sStat = "Open"
                Case "P"
                    sStat = "Month-End Process"
                Case "Q"
                    sStat = "Internal PPCC QC"
                Case "R"
                    sStat = "Re-Open"
                Case "S"
                    sStat = "Solution Finding"
                Case "T"
                    sStat = "Test on CRP/UAT-QC"
                Case "U"
                    sStat = "Move to CRP/UAT"
                Case "V"
                    sStat = "Investigate"
                Case "W"
                    sStat = "Awaiting Customer"
                Case "X"
                    sStat = "Awaiting Customer for Closed"
                Case "Z"
                    sStat = "Issue List"
                Case Else
                    sStat = "Open"
            End Select
        End Set
    End Property

End Class
