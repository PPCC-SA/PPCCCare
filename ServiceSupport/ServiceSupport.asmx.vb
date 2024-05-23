Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ServiceSupport
    Inherits System.Web.Services.WebService

    Private strConn As String = ConfigurationManager.ConnectionStrings("Conn").ToString

    <WebMethod()>
    Public Function LoginSupport(username As String, password As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("ppcc_support_loginsp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@username", username)
                .Parameters.AddWithValue("@password", password)
                '.Parameters.AddWithValue("@category", category)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function CustomerLogList(username As String, filter As String, type As String, custnum As String _
                                    , submittedDate As DateTime, stat As String, suptype As String, req As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("ppcc_customerloglistSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@username", username)
                .Parameters.AddWithValue("@filter", filter)
                .Parameters.AddWithValue("@type", type)
                .Parameters.AddWithValue("@customer", custnum)
                .Parameters.AddWithValue("@SubmittedDate", submittedDate)
                .Parameters.AddWithValue("@Stat", stat)
                .Parameters.AddWithValue("@SupType", suptype)
                .Parameters.AddWithValue("@Requestor", req)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function LogDetail(log_id As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("ppcc_customerlogDetailSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@log_id", log_id)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function


    <WebMethod()>
    Public Function GetCustomer(sCustGroup As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("ppcc_GetCustomerSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@cust_group", sCustGroup)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function SignupSupport(username As String, password As String, customer As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("ppcc_SupportSignupSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@username", username)
                .Parameters.AddWithValue("@password", password)
                .Parameters.AddWithValue("@customer", customer)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetStatusSupport() As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("ppcc_getStatSupportSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function
    <WebMethod()>
    Public Function GetTypeSupport() As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("ppcc_getTypeSupportSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetRequestorSupport(customer As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("ppcc_getRequestorSupportSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@customer", customer)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetSupportLogReport(StartCust As String, EndCust As String, StartReqDate As Date, EndReqDate As Date, Open As Integer, Inprocess As Integer, Close As Integer, CustGroup As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("Rpt_PPCC_SubportLogForWebSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@sCust", StartCust)
                .Parameters.AddWithValue("@eCust", EndCust)
                .Parameters.AddWithValue("@sReq", StartReqDate)
                .Parameters.AddWithValue("@eReq", EndReqDate)
                .Parameters.AddWithValue("@sOpen", Open)
                .Parameters.AddWithValue("@sInprocess", Inprocess)
                .Parameters.AddWithValue("@sClose", Close)
                .Parameters.AddWithValue("@CustGroup", CustGroup)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function


    <WebMethod()>
    Public Function InsertSupportLog(LogID As String, Stat As String, CustNum As String, DBSite As String, FormName As String, Subject As String, Problem As String, Attachment As String, Email As String, Requestor As String, sModule As String, sSeverity As String, sProgramGroup As String, dProjectDate As Date, dRequestDate As Date, iAfterWork As Integer, iHoliday As Integer, sInform As String, sCause As String, sHowtoCheck As String, sCurrentSol As String, sLongTermSol As String, sRequestTime As String, sAcknowledgeBy As String, dResponseDate As Date, sResponseTime As String, User As String) As DataTable

        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_InsertSupportLogSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@LogID", LogID)
                .Parameters.AddWithValue("@Stat", Stat)
                .Parameters.AddWithValue("@CustNum", CustNum)
                .Parameters.AddWithValue("@DatabaseSite", DBSite)
                .Parameters.AddWithValue("@FormName", FormName)
                '.Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@Subject", Subject)
                .Parameters.AddWithValue("@Problem", Problem)
                '.Parameters.AddWithValue("@ErrorType", ErrorType)
                .Parameters.AddWithValue("@Attachment", Attachment)
                .Parameters.AddWithValue("@EMail", Email)
                .Parameters.AddWithValue("@Requestor", Requestor)
                .Parameters.AddWithValue("@Module", sModule)
                .Parameters.AddWithValue("@Severity", sSeverity)
                .Parameters.AddWithValue("@ProgramGroup", sProgramGroup)
                .Parameters.AddWithValue("@ProjectDate", dProjectDate)
                .Parameters.AddWithValue("@RequestDate", dRequestDate)
                .Parameters.AddWithValue("@AfterWork", iAfterWork)
                .Parameters.AddWithValue("@Holiday", iHoliday)
                .Parameters.AddWithValue("@Inform", sInform)
                .Parameters.AddWithValue("@Cause", sCause)
                .Parameters.AddWithValue("@HowtoCheck", sHowtoCheck)
                .Parameters.AddWithValue("@CurrentSol", sCurrentSol)
                .Parameters.AddWithValue("@LongTermSol", sLongTermSol)
                .Parameters.AddWithValue("@RequestTime", sRequestTime)
                .Parameters.AddWithValue("@AcknowledgeBy", sAcknowledgeBy)
                .Parameters.AddWithValue("@RespondDate", dResponseDate)
                .Parameters.AddWithValue("@RespondTime", sResponseTime)
                .Parameters.AddWithValue("@User", User)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetDatabaseSite(CustNum As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetDatabaseSiteSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@cust_num", CustNum)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetEmailRequestor(CustNum As String, Req As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetEmailRequestorSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@cust_num", CustNum)
                .Parameters.AddWithValue("@Req", Req)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetResource() As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetResourceSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetErrorType() As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetErrorTypeSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function UpdateSupportLog(LogId As String, Stat As String, Cause As String, Solution As String, ErrorType As String, Responsible As String, ClosedBy As String, Problem As String, User As String, HowtoCheck As String, CurrentSol As String, LongTermSol As String, RespondDate As Date, RespondTime As String, EndDate As Date, EndTime As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_UpdateSupportLogSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@log_id", LogId)
                .Parameters.AddWithValue("@stat", Stat)
                .Parameters.AddWithValue("@cause", Cause)
                .Parameters.AddWithValue("@solution", Solution)
                .Parameters.AddWithValue("@err_type", ErrorType)
                .Parameters.AddWithValue("@responsible", Responsible)
                .Parameters.AddWithValue("@closedby", ClosedBy)
                .Parameters.AddWithValue("@problem", Problem)
                .Parameters.AddWithValue("@user", User)
                .Parameters.AddWithValue("@HowtoCheck", HowtoCheck)
                .Parameters.AddWithValue("@CurrentSol", CurrentSol)
                .Parameters.AddWithValue("@LongTermSol", LongTermSol)
                .Parameters.AddWithValue("@RespondDate", RespondDate)
                .Parameters.AddWithValue("@RespondTime", RespondTime)
                .Parameters.AddWithValue("@EndDate", EndDate)
                .Parameters.AddWithValue("@EndTime", EndTime)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetSupportModule() As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetSupportModuleSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetRequestor(CustNum As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetRequestorSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@cust_num", CustNum)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function InsertRequestor(Company As String, Req As String, FirstName As String, LastName As String, Email As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_InsertRequestorSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Company", Company)
                .Parameters.AddWithValue("@Req", Req)
                .Parameters.AddWithValue("@FirstName", FirstName)
                .Parameters.AddWithValue("@LastName", LastName)
                .Parameters.AddWithValue("@Email", Email)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function InsertReplyLog(LogId As String, Reply As String, Username As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_InsertReplyLogSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@LogID", LogId)
                .Parameters.AddWithValue("@Reply", Reply)
                .Parameters.AddWithValue("@User", Username)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetReplyLog(LogId As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetReplyLogSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@LogID", LogId)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetIssueSummaryReport(StartCust As String, EndCust As String, StartReqDate As Date, EndReqDate As Date, CustGroup As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        Dim strSubSQL As New StringBuilder


        Dim SqlCons As New SqlConnection
        Dim SqlCmds As New SqlCommand
        Dim dts As New DataTable("data1")
        Dim das As New SqlDataAdapter
        Dim dss As New DataSet
        Dim strConnStrings As String



        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        strConnStrings = strConn
        SqlCon.ConnectionString = strConnString
        SqlCons.ConnectionString = strConnString
        strSubSQL.Append("rpt_PPCC_Issuesummary")
        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSubSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Starting_cust", StartCust)
                .Parameters.AddWithValue("@Ending_cust", EndCust)
                .Parameters.AddWithValue("@Starting_inv_date", StartReqDate)
                .Parameters.AddWithValue("@Ending_inv_date", EndReqDate)
                .Parameters.AddWithValue("@cust_group", CustGroup)

            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing
        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
        'Return dts

    End Function

    <WebMethod()>
    Public Function GetIssueSummaryReports(StartCust As String, EndCust As String, StartReqDate As Date, EndReqDate As Date, CustGroup As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        Dim strSubSQL As New StringBuilder


        Dim SqlCons As New SqlConnection
        Dim SqlCmds As New SqlCommand
        Dim dts As New DataTable("data1")
        Dim das As New SqlDataAdapter
        Dim dss As New DataSet
        Dim strConnStrings As String



        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        strConnStrings = strConn
        SqlCon.ConnectionString = strConnString
        SqlCons.ConnectionString = strConnString
        strSQL.Append("rpt_PPCC_SubIssuesummary") 'report หลัก'
        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Starting_cust", StartCust)
                .Parameters.AddWithValue("@Ending_cust", EndCust)
                .Parameters.AddWithValue("@Starting_inv_date", StartReqDate)
                .Parameters.AddWithValue("@Ending_inv_date", EndReqDate)
                .Parameters.AddWithValue("@cust_group", CustGroup)


            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing
        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
        'Return dts

    End Function

    <WebMethod()>
    Public Function GetUserWebSupport() As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetUserSupportSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                '.Parameters.AddWithValue("@LogID", LogId)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function InsertUserWebSupport(sUsername As String, sPassword As String, sCustomer As String, sCategory As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_InsertUserWebSupportSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Username", sUsername)
                .Parameters.AddWithValue("@Password", sPassword)
                .Parameters.AddWithValue("@Customer", sCustomer)
                .Parameters.AddWithValue("@Category", sCategory)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function UpdateUserWebSupport(sUsername As String, sPassword As String, sCustomer As String, sCategory As String, sRowPointer As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_UpdateUserSupportSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Username", sUsername)
                .Parameters.AddWithValue("@Password", sPassword)
                .Parameters.AddWithValue("@Customer", sCustomer)
                .Parameters.AddWithValue("@Category", sCategory)
                .Parameters.AddWithValue("@RowPointer", sRowPointer)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function DeleteUserWebSupport(sRowPointer As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_DeleteUserSupportSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@RowPointer", sRowPointer)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function UpdateRequestor(sReq As String, sName As String, sLastName As String, sEmail As String, sCustomer As String, sRowPointer As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_UpdateRequestorSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Requestor", sReq)
                .Parameters.AddWithValue("@Name", sName)
                .Parameters.AddWithValue("@LastName", sLastName)
                .Parameters.AddWithValue("@Email", sEmail)
                .Parameters.AddWithValue("@Customer", sCustomer)
                .Parameters.AddWithValue("@RowPointer", sRowPointer)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function DeleteRequestor(sRowPointer As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_DeleteRequestorSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@RowPointer", sRowPointer)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetSeverity() As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetSeveritySp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                '.Parameters.AddWithValue("@LogID", LogId)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetProgramGroup(sModule As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetProgramGroupSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Module", sModule)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetProjectedDate(sCurrDate As Date, iSeverity As Integer, sShift As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_CalculateWorkingDateByShiftSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@curr_date", sCurrDate)
                .Parameters.AddWithValue("@severity", iSeverity)
                .Parameters.AddWithValue("@Shift", sShift)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function GetCustomerEmailSupport(sCustNum As String) As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetCustomerEmailSupportSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@cust_num", sCustNum)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function
    <WebMethod()>
    Public Function GetInformProblem() As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetInformProblemSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
                '.Parameters.AddWithValue("@cust_num", CustNum)
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function
    <WebMethod()>
    Public Function GetResponse() As DataTable
        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim dt As New DataTable("data")
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim strConnString As String
        Dim strSQL As New StringBuilder
        'Dim Trans As SqlTransaction

        'Trans = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted)

        strConnString = strConn
        SqlCon.ConnectionString = strConnString
        strSQL.Append("PPCC_GetResponseIDSp")

        Try
            SqlCon.ConnectionString = strConnString
            With SqlCmd
                .Connection = SqlCon
                .CommandText = strSQL.ToString()
                .CommandType = CommandType.StoredProcedure
            End With

            da.SelectCommand = SqlCmd
            da.Fill(ds)
            dt = ds.Tables(0)

            ' Trans.Commit()

            da = Nothing
            SqlCon.Close()
            SqlCon = Nothing

        Catch ex As Exception
            'Trans.Rollback()
        End Try

        Return dt
    End Function
End Class