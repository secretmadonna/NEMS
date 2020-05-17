<%@ Page Language="C#" AutoEventWireup="true" %>

<html>
<head>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<title>eWebEditor �� ��ҳ��ʾ����ʾ��</title>
<meta http-equiv="Content-Type" content="text/html; charset=gbk" />
<link rel="stylesheet" type="text/css" href="example.css" />
</head>
<body>

<p><b>���� �� <a href="default.aspx">ʾ����ҳ</a> &gt; ��ҳ��ʾ����ʾ��</b></p>
<p>������ʾ��eWebEditor�ı�׼��ҳģʽ�£�����Ա�׼��ҳ���Ĵ������������Բ鿴��ҳ����Դ���룬���˽��׼��ҳ���ṹ��ʹ�÷�����</p>


<%
// eWebEditor ��׼��ҳ����ʽ���壺
// -------------------------------------------------------------------
// <!--ewebeditor:page title="��NҳС����"-->
// ��Nҳ����HTML����
// <!--/ewebeditor:page-->
// -------------------------------------------------------------------





// sContent���������༭�����ݣ�һ���Ǵ����ݿ���ȡ��������Ϊģ������
    String sContent;
// sContent = rs("field")
sContent = "<!--ewebeditor:page title=\"��һҳС����\"-->" + "\r\n" +
           "<style>" + "\r\n" +
		   ".p1{font-size:14px;color:#000000;}" + "\r\n" +
		   ".p2{font-size:16px;color:#ff0000;}" + "\r\n" +
		   ".p3{font-size:18px;color:#0000ff;}" + "\r\n" +
		   "</style>" + "\r\n" +
           "<p class=p1>��һҳ����</p>" + "\r\n" + 
           "<!--/ewebeditor:page-->" + "\r\n" + 
		   "<!--ewebeditor:page title=\"�ڶ�ҳС����\"-->" + "\r\n" + 
           "<p class=p2>�ڶ�ҳ����</p>" + "\r\n" + 
           "<!--/ewebeditor:page-->" + "\r\n" + 
		   "<!--ewebeditor:page title=\"����ҳС����\"-->" + "\r\n" + 
           "<p class=p3>����ҳ����</p>" + "\r\n" + 
           "<!--/ewebeditor:page-->";
//sContent = "<p>ֻ��һҳ��</p>"



String[] arr;
String sPage, sOutputTitles, sOutputContent;
sPage = Request["page"]+"";
arr = eWebEditorPagination(sContent, sPage);
sOutputContent = arr[1];
sOutputTitles = arr[2];

// ��ʾ�����б���ҳ����
if (sOutputTitles != ""){
	Response.Write("<hr size=1>");
	Response.Write(sOutputTitles);
}

// ��ʾ����
Response.Write("<hr size=1>");
Response.Write(sOutputContent);

%>

<script language="c#" runat="server">

    // eWebEditor ��׼��ҳ����ʽ���壺
    // -------------------------------------------------------------------
    // <!--ewebeditor:page title="��NҳС����"-->
    // ��Nҳ����HTML����
    // <!--/ewebeditor:page-->
    // -------------------------------------------------------------------
    // eWebEditor��׼��ҳ������������ʾ��, ����ʵ����Ҫ�޸�, ���ض�ֵ����
    // -------------------------------------------------------------------
    String[] eWebEditorPagination(String s_Content, String s_CurrPage){
        // С�����б���ǰҳ���⣬��ǰҳ����
        String s_Titles, s_CurrTitle, s_CurrContent;
        s_Titles = "";
        s_CurrTitle = "";
        s_CurrContent = s_Content;

        // ҳ����0��ʾû�з�ҳ
        int n_PageCount;
        n_PageCount = 0;

        // ��ǰҳ
        int n_CurrPage;
        n_CurrPage = 1;

        // ���з�ҳʱ�����ҳ���ĺͱ�������飬�±��1��ʼ
        String[] a_PageContent = new String[1000];
        String[] a_PageTitle = new String[1000];

        // ������ʽ����
        System.Text.RegularExpressions.MatchCollection ms;
        String s_Pattern;

        // ����������е�CSS��ʽ���֣�Ȼ���ڸ�ҳ�кϲ���ʹ����ҳ����ʾЧ������
        // <style>...</style>
        String s_Style;
        s_Style = "";
        s_Pattern = "<style[^>]*>(.+?)</style>";
        ms = System.Text.RegularExpressions.Regex.Matches(s_CurrContent, s_Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
        if (ms.Count > 0){
            for (int i=0; i<ms.Count; i++){
                s_Style = "\r\n" + s_Style + ms[i].Value + "\r\n";
            }
            s_CurrContent = System.Text.RegularExpressions.Regex.Replace(s_CurrContent, s_Pattern, "", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
        }

        // ʹ��������ʽ�Է�ҳ���д���
        s_Pattern = "<!--ewebeditor:page title=\"([^\">]*)\"-->(.+?)<!--/ewebeditor:page-->";
        ms = System.Text.RegularExpressions.Regex.Matches(s_CurrContent, s_Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
		for (int i=0; i<ms.Count; i++){
            n_PageCount = n_PageCount + 1;
            a_PageTitle[n_PageCount] = ms[i].Groups[1].Value;
            a_PageContent[n_PageCount] = ms[i].Groups[2].Value;
		}

        if (n_PageCount == 0){
            // û�з�ҳ
            s_Titles = "";
            s_CurrContent = s_Content;
        }else{
            // �з�ҳ
            // �Ӳ����жϵ�ǰҳ����Ч��
            if (s_CurrPage==""){
                n_CurrPage = 1;
            }else{
                n_CurrPage = int.Parse(s_CurrPage);
                if ((n_CurrPage < 1) || (n_CurrPage > n_PageCount)){
                    n_CurrPage = 1;
                }
            }

            // ���ж��ҳʱ����ʾ��ҳС���⼰��ҳ����
            s_Titles = "";
            for (int i=1;i<=n_PageCount;i++){
                if (i == n_CurrPage){
                    s_Titles = s_Titles + "<li>" + i + ") " + a_PageTitle[i] + "";
                }else{
                    s_Titles = s_Titles + "<li><a href='?page=" + i + "'>" + i + ") " + a_PageTitle[i] + "</a>";
                }
            }

            // ��ǰҳ���������
            s_CurrTitle = a_PageTitle[n_CurrPage];
            s_CurrContent = s_Style + a_PageContent[n_CurrPage];
        }

        // ����ֵ���飬��ʵ����Ҫ�޸�
        String[] ret = new String[4];
        ret[1] = s_CurrContent;  //��ǰҳ����
        ret[2] = s_Titles;       //�����б�
        ret[3] = s_CurrTitle;    //��ǰҳ����

        return ret;
    }
</script>

</body>
</html>