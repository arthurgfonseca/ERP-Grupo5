<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="Teste.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />

