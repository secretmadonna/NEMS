<HTML>
<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7">
<TITLE>eWebEditor �� ��ҳ��ʾ����ʾ��</TITLE>
<META http-equiv=Content-Type content="text/html; charset=gbk">
<link rel='stylesheet' type='text/css' href='example.css'>
</HEAD>
<BODY>

<p><b>���� �� <a href="default.aspx">ʾ����ҳ</a> &gt; ��ҳ��ʾ����ʾ��</b></p>
<p>������ʾ��eWebEditor�ı�׼��ҳģʽ�£�����Ա�׼��ҳ���Ĵ������������Բ鿴��ҳ����Դ���룬���˽��׼��ҳ���ṹ��ʹ�÷�����</p>


<%
' eWebEditor ��׼��ҳ����ʽ���壺
' -------------------------------------------------------------------
' <!--ewebeditor:page title="��NҳС����"-->
' ��Nҳ����HTML����
' <!--/ewebeditor:page-->
' -------------------------------------------------------------------





' sContent���������༭�����ݣ�һ���Ǵ����ݿ���ȡ��������Ϊģ������
Dim sContent
' sContent = rs("field")
sContent = "<!--ewebeditor:page title=""��һҳС����""-->" & vbCrlf & _
           "<style>" & vbCrlf & _
		   ".p1{font-size:14px;color:#000000;}" & vbCrlf & _
		   ".p2{font-size:16px;color:#ff0000;}" & vbCrlf & _
		   ".p3{font-size:18px;color:#0000ff;}" & vbCrlf & _
		   "</style>" & vbCrlf & _
           "<p class=p1>��һҳ����</p>" & vbCrlf & _
           "<!--/ewebeditor:page-->" & vbCrlf & _
		   "<!--ewebeditor:page title=""�ڶ�ҳС����""-->" & vbCrlf & _
           "<p class=p2>�ڶ�ҳ����</p>" & vbCrlf & _
           "<!--/ewebeditor:page-->" & vbCrlf & _
		   "<!--ewebeditor:page title=""����ҳС����""-->" & vbCrlf & _
           "<p class=p3>����ҳ����</p>" & vbCrlf & _
           "<!--/ewebeditor:page-->"
'sContent = "<p>ֻ��һҳ��</p>"



Dim arr, sPage, sOutputTitles, sOutputContent
sPage = Trim(Request("page"))
arr = eWebEditorPagination(sContent, sPage)
sOutputContent = arr(1)
sOutputTitles = arr(2)

' ��ʾ�����б���ҳ����
If sOutputTitles <> "" Then
	Response.Write("<hr size=1>")
	Response.Write(sOutputTitles)
End If

' ��ʾ����
Response.Write("<hr size=1>")
Response.Write(sOutputContent)

%>

<script language="vb" runat="server">

    ' eWebEditor ��׼��ҳ����ʽ���壺
    ' -------------------------------------------------------------------
    ' <!--ewebeditor:page title="��NҳС����"-->
    ' ��Nҳ����HTML����
    ' <!--/ewebeditor:page-->
    ' -------------------------------------------------------------------
    ' eWebEditor��׼��ҳ������������ʾ��, ����ʵ����Ҫ�޸�, ���ض�ֵ����
    ' -------------------------------------------------------------------
    Function eWebEditorPagination(ByVal s_Content As String, ByVal s_CurrPage As String) As Array
        ' С�����б���ǰҳ���⣬��ǰҳ����
        Dim s_Titles As String, s_CurrTitle As String, s_CurrContent As String
        s_Titles = ""
        s_CurrTitle = ""
        s_CurrContent = s_Content

        ' ҳ����0��ʾû�з�ҳ
        Dim n_PageCount As Integer
        n_PageCount = 0

        ' ��ǰҳ
        Dim n_CurrPage As Integer
        n_CurrPage = 1

        ' ���з�ҳʱ�����ҳ���ĺͱ�������飬�±��1��ʼ
        Dim a_PageContent() As String, a_PageTitle() As String

        ' ������ʽ����
        Dim re As System.Text.RegularExpressions.Regex
        Dim m As System.Text.RegularExpressions.Match
        Dim ms As System.Text.RegularExpressions.MatchCollection
        Dim s_Pattern As String

        ' ����������е�CSS��ʽ���֣�Ȼ���ڸ�ҳ�кϲ���ʹ����ҳ����ʾЧ������
        ' <style>...</style>
        Dim s_Style As String
        s_Style = ""
        s_Pattern = "<style[^>]*>(.+?)</style>"
        ms = re.Matches(s_CurrContent, s_Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline)
        If ms.Count > 0 Then
            For Each m In ms
                s_Style = vbCrLf & s_Style & m.Value & vbCrLf
            Next
            s_CurrContent = re.Replace(s_CurrContent, s_Pattern, "", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline)
        End If

        ' ʹ��������ʽ�Է�ҳ���д���
        s_Pattern = "<!--ewebeditor:page title=""([^"">]*)""-->(.+?)<!--/ewebeditor:page-->"
        ms = re.Matches(s_CurrContent, s_Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline)
        For Each m In ms
            n_PageCount = n_PageCount + 1
            ReDim Preserve a_PageTitle(n_PageCount)
            ReDim Preserve a_PageContent(n_PageCount)
            a_PageTitle(n_PageCount) = m.Groups(1).Value
            a_PageContent(n_PageCount) = m.Groups(2).Value
		Next

        If n_PageCount = 0 Then
            ' û�з�ҳ
            s_Titles = ""
            s_CurrContent = s_Content
        Else
            ' �з�ҳ
            ' �Ӳ����жϵ�ǰҳ����Ч��
            If IsNumeric(s_CurrPage) = False Then
                n_CurrPage = 1
            Else
                n_CurrPage = CInt(s_CurrPage)
                If n_CurrPage < 1 Or n_CurrPage > n_PageCount Then
                    n_CurrPage = 1
                End If
            End If

            Dim i As Integer
            ' ���ж��ҳʱ����ʾ��ҳС���⼰��ҳ����
            s_Titles = ""
            For i = 1 To n_PageCount
                If i = n_CurrPage Then
                    s_Titles = s_Titles & "<li>" & i & ") " & a_PageTitle(i) & ""
                Else
                    s_Titles = s_Titles & "<li><a href='?page=" & i & "'>" & i & ") " & a_PageTitle(i) & "</a>"
                End If
            Next

            ' ��ǰҳ���������
            s_CurrTitle = a_PageTitle(n_CurrPage)
            s_CurrContent = s_Style & a_PageContent(n_CurrPage)
        End If

        ' ����ֵ���飬��ʵ����Ҫ�޸�
        Dim ret(3) As String
        ret(1) = s_CurrContent  '��ǰҳ����
        ret(2) = s_Titles   '�����б�
        ret(3) = s_CurrTitle  '��ǰҳ����

        eWebEditorPagination = ret
    End Function
</script>

</BODY>
</HTML>