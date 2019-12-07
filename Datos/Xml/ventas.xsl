<?xml version='1.0' encoding="iso-8859-1"?>
<xsl:stylesheet version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
    
    <xsl:template match="/">
    <table width="240" border="1pt" cellspacing="0" cellpadding="3" bordercolor="#dddddd" style="border-collapse:collapse;" class="Modulo">
        <tr>
            <th align="left">Categoria <br/>del Producto</th>
            <th>Ganancia (Millones)</th>
            <th>Diferencia</th>
        </tr>
        <xsl:for-each select='sales/product'>
            <tr>
                <td width="100">
                    <i><xsl:value-of select='@id'/></i>
                </td>
                <td width="100"> 
                    <CENTER>
                        <xsl:value-of select='revenue'/>
                    </CENTER>
                </td>
                <td>
                    <xsl:if test='growth &lt; 0'>
                        <xsl:attribute name='style'>
                            <xsl:text>color:red</xsl:text>
                        </xsl:attribute>
                    </xsl:if>
                    <CENTER>
                        <xsl:value-of select='growth'/>
                    </CENTER>
                </td>
            </tr>
        </xsl:for-each>
    </table>
    </xsl:template>
    
</xsl:stylesheet>
