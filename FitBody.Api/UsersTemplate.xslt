<?xml version="1.0"?>
<?mso-application progid="Excel.Sheet"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="urn:schemas-microsoft-com:office:spreadsheet" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet" version="1.0">
  <xsl:output method="xml" indent="yes" encoding="utf-8"/>
  <xsl:template match="ArrayOfUserReportDto">
    <xsl:processing-instruction name="mso-application">
      <xsl:text>progid="Excel.Sheet"</xsl:text>
    </xsl:processing-instruction>

<Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
 xmlns:o="urn:schemas-microsoft-com:office:office"
 xmlns:x="urn:schemas-microsoft-com:office:excel"
 xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
 xmlns:html="http://www.w3.org/TR/REC-html40">
 <OfficeDocumentSettings xmlns="urn:schemas-microsoft-com:office:office">
  <AllowPNG/>
 </OfficeDocumentSettings>
 <Styles>
  <Style ss:ID="Default" ss:Name="Normal">
   <Alignment ss:Vertical="Bottom"/>
   <Borders/>
   <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
   <Interior/>
   <NumberFormat/>
   <Protection/>
  </Style>
 </Styles>
 <Worksheet ss:Name="Report">
  <Table x:FullColumns="1" x:FullRows="1" ss:DefaultRowHeight="15">
   <!-- Header -->
   <Row>
    <Cell><Data ss:Type="String">Id</Data></Cell>
    <Cell><Data ss:Type="String">First Name</Data></Cell>
    <Cell><Data ss:Type="String">Last Name</Data></Cell>
    <Cell><Data ss:Type="String">Username</Data></Cell>
    <Cell><Data ss:Type="String">Birthdate</Data></Cell>
    <Cell><Data ss:Type="String">Phone number</Data></Cell>
    <Cell><Data ss:Type="String">Email</Data></Cell>
    <Cell><Data ss:Type="String">Info</Data></Cell>
    <Cell><Data ss:Type="String">Height</Data></Cell>
    <Cell><Data ss:Type="String">Weight</Data></Cell>
    <Cell><Data ss:Type="String">Active</Data></Cell>
    <Cell><Data ss:Type="String">Followers</Data></Cell>
   </Row>
   <!-- End header -->
   <!-- Report Data -->
   <xsl:for-each select="UserReportDto">
       <Row>
		<Cell><Data ss:Type="Number"><xsl:value-of select="Id" /></Data></Cell>
		<Cell><Data ss:Type="String"><xsl:value-of select="FirstName" /></Data></Cell>
		<Cell><Data ss:Type="String"><xsl:value-of select="LastName" /></Data></Cell>
		<Cell><Data ss:Type="String"><xsl:value-of select="UserName" /></Data></Cell>
		<Cell><Data ss:Type="String"><xsl:value-of select="ms:format-date(BirthDate, 'dd.MM.yyyy')"/></Data></Cell>
		<Cell><Data ss:Type="String"><xsl:value-of select="Mobile" /></Data></Cell>
		<Cell><Data ss:Type="String"><xsl:value-of select="Email" /></Data></Cell>
		<Cell><Data ss:Type="String"><xsl:value-of select="Info" /></Data></Cell>
		<Cell><Data ss:Type="Number"><xsl:value-of select="Height" /></Data></Cell>
		<Cell><Data ss:Type="Number"><xsl:value-of select="Weight" /></Data></Cell>
		<Cell><Data ss:Type="String"><xsl:value-of select="Active" /></Data></Cell>
		<Cell><Data ss:Type="Number"><xsl:value-of select="Followers" /></Data></Cell>
	   </Row>
   </xsl:for-each>
   <!-- End Report Data -->
  </Table>
 </Worksheet>
</Workbook>
  </xsl:template>
</xsl:stylesheet>