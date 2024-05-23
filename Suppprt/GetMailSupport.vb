Public Class GetMailSupport

    Public Function GetMailSupport(ByVal Customer As String) As String
        Dim mail As String = String.Empty
        Select Case Customer
            Case "ADI"
                mail = "adi.support@ppcc.co.th"
            Case "ART"
                mail = "art.support@ppcc.co.th"
            Case "BISW"
                mail = "bisw.support@ppcc.co.th"
            Case "CCH"
                mail = "cch.support@ppcc.co.th"
            Case "HA"
                mail = "ha.support@ppcc.co.th"
            Case "NST"
                mail = "nst.support@ppcc.co.th"
            Case "NTH"
                mail = "nth.support@ppcc.co.th"
            Case "OTC"
                mail = "otc.support@ppcc.co.th"
            Case "PK"
                mail = "pk.support@ppcc.co.th"
            Case "RX"
                mail = "rx.support@ppcc.co.th"
            Case "SNPR"
                mail = "snpr.support@ppcc.co.th"
            Case "SRN"
                mail = "srn.support@ppcc.co.th"
            Case "SST"
                mail = "sst.support@ppcc.co.th"
            Case "TAYO"
                mail = "taiyo.support@ppcc.co.th"
            Case "TAK"
                mail = "tak.support@ppcc.co.th"
            Case "TG"
                mail = "tg.support@ppcc.co.th"
            Case "TTSC"
                mail = "ttsc.support@ppcc.co.th"
            Case Else
                mail = "support@ppcc.co.th"
        End Select

        Return mail
    End Function
End Class
