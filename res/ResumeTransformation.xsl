<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <html>
            <head>
                <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.0/css/bootstrap.min.css"
                      integrity="sha384-PDle/QlgIONtM1aqA2Qemk5gPOE7wFq8+Em+G/hmo5Iq0CCmYZLv3fVRDJ4MMwEA"
                      crossorigin="anonymous">
                </link>
                <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"
                        integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"
                        crossorigin="anonymous"></script>
                <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
                        integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"
                        crossorigin="anonymous"></script>
                <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.0/js/bootstrap.min.js"
                        integrity="sha384-7aThvCh9TypR7fIc2HV4O/nFMVCBwyIUKL8XCtKE+8xgCgl/PQGuFsvShjr74PBp"
                        crossorigin="anonymous"></script>
                <link rel="stylesheet" href="style.css" type="text/css"/>
                <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
                <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet" />
                <meta name="viewport" content="initial-scale=1.0, user-scalable=no"/>
                <meta charset="utf-8"/>
                <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDsGkcJrnY2IN7ZvX3gexkvcDBq-ypHFGA"/>
                <script src="gmap.js">
                    <xsl:attribute name="query">
                        <xsl:value-of select="curriculum/address/street"/> <xsl:value-of
                            select="curriculum/address/number"/>, <xsl:value-of select="curriculum/address/city"/>,
                        <xsl:value-of select="curriculum/address/state"/> ,
                        <xsl:value-of select="curriculum/address/zipcode"/>
                    </xsl:attribute>
                </script>
            </head>
            <body>
                <div>
                    <!-- Grid container -->
                    <div class="grid-container" id="main-container">
                        <!-- Grid item: left panel -->
                        <div id="left-panel" class="grid-item">
                            <div>
                                <div class="aligncenter">
                                    <img id="profile"><xsl:attribute name="src">data:image/gif;base64,<xsl:value-of select="curriculum/photo"/></xsl:attribute></img>
                                </div>
                                <div>
                                    <div class="center-txt" id="title-ms">Software Engineer</div>
                                    <div class="content-bg spacebox">
                                    </div>
                                    <div class = "subsection-title-txt">
                                        CONTACTO
                                    </div>
                                    <div class="grid-container content-bg sub-container">
                                        <div class="grid-item">
                                            <div class="d-flex justify-content-center">
                                                <i class="material-icons">phone</i>
                                            </div>
                                            <div class="d-flex justify-content-center">Número celular</div>
                                            <div class="d-flex justify-content-center">
                                                <xsl:value-of select="curriculum/phone"/>
                                            </div>
                                        </div>
                                        <div id="email-data grid-item">
                                            <xsl:variable name="typeemail" select="curriculum/email/@type"/>
                                            <xsl:choose>
                                                <xsl:when test="$typeemail = 'PERSONAL'">
                                                    <div class="d-flex justify-content-center">
                                                        <i class="material-icons md-96 md-dark">face</i>
                                                    </div>
                                                    <div class="d-flex justify-content-center">Email personal</div>
                                                </xsl:when>
                                                <xsl:when test="$typeemail = 'WORK'">
                                                    <div class="d-flex justify-content-center">
                                                        <i class="material-icons md-96 md-dark">work</i>
                                                    </div>
                                                    <div class="d-flex justify-content-center">Email laboral</div>
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <div class="d-flex justify-content-center">
                                                        <i class="material-icons md-96 md-dark">
                                                            indeterminate_check_box
                                                        </i>
                                                    </div>
                                                    <div class="d-flex justify-content-center">Email</div>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                            <div class="d-flex justify-content-center">
                                                <i class="material-icons"></i>
                                                <xsl:value-of select="concat('',curriculum/email)"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="subsection-title-txt">
                                        DIRECCION
                                    </div>
                                    <div id="address-data" class="content-bg">
                                        <div id="map"/>
                                        <div class="center-txt">
                                            <xsl:value-of select="curriculum/address/street"/>&#160;<xsl:value-of select="curriculum/address/number"/>,&#160;<xsl:value-of
                                                select="curriculum/address/zipcode"/>,&#160;<xsl:value-of select="curriculum/address/city"/>,&#160;<xsl:value-of select="curriculum/address/state"/>
                                            <div class="spacebox2 content-bg" /></div>
                                    </div>
                                </div>
                            </div>
                        </div><!-- End grid item: left panel -->
                        <!-- Grid item: right panel -->
                        <div id="right-panel" class="grid-item">
                            <div id="name" class="titles"><xsl:value-of select="curriculum/name"/></div>
                            <div class="titles">EXPERIENCIA</div>
                                <xsl:for-each select="curriculum/jobs/job">
                                <xsl:variable name="endDate" select="substring(enddate, 1, 10)"/>
                                <xsl:variable name="startDate" select="substring(startdate, 1, 10)"/>
                                    <table>
                                    <thead>
                                            <th><xsl:value-of select="company"/></th>
                                            <th>Ene</th>
                                            <th>Feb</th>
                                            <th>Mar</th>
                                            <th>Abr</th>
                                            <th>May</th>
                                            <th>Jun</th>
                                            <th>Jul</th>
                                            <th>Ago</th>
                                            <th>Sep</th>
                                            <th>Oct</th>
                                            <th>Nov</th>
                                            <th>Dic</th>
                                    </thead>
                                    <tbody>
                                    <xsl:variable name="nextYear" select="2020"/>

                                    <xsl:variable name="startValueYear" select="substring($startDate, 1, 4)* 12"/>
                                    <xsl:variable name="startValueMonth" select="substring($startDate, 6, 2)+ 0"/>

                                    <xsl:variable name="startValue" select="$startValueYear + $startValueMonth + 0"/>

                                    <xsl:variable name="endValueYear" select="substring($endDate, 1, 4)* 12"/>
                                    <xsl:variable name="endValueMonth" select="substring($endDate, 6, 2)+ 0"/>

                                    <xsl:variable name="endValue" select="$endValueYear + $endValueMonth + 0"/>

                                    <xsl:variable name="finalYear" select="substring($endDate, 1, 4)+0"/>
                                    <xsl:variable name="startYear" select="substring($startDate, 1, 4)+0"/>
                                    <xsl:variable name="years" select="$finalYear - $startYear"/>
                                    <xsl:for-each select="(//node())[$years >= position()-1]">
                                    <xsl:variable name="iterator" select="(substring($startDate, 1, 4)+position()-1)*12"/>
                                        <tr>
                                            <td><xsl:value-of select="substring($startDate, 1, 4)+position()-1"/></td>

                                            <xsl:for-each select="(//node())[12 >= position()]">
                                                <xsl:choose>
                                                    <xsl:when test = "($iterator + position() = $startValue)">
                                                        <td class="highlight"><xsl:value-of select="substring($startDate,9,2)+0"/></td>
                                                    </xsl:when>
                                                    <xsl:when test = "($iterator + position() = $endValue)">
                                                        <td class="highlight"><xsl:value-of select="substring($endDate,9,2)+0"/></td>
                                                    </xsl:when>
                                                    <xsl:when test = "($iterator + position() - 1 &gt;= $startValue) and ($iterator + position() - 1 &lt; $endValue)">
                                                        <td class="highlight"></td>
                                                    </xsl:when>
                                                    <xsl:otherwise>
                                                        <td></td>
                                                    </xsl:otherwise>
                                                </xsl:choose>
                                            </xsl:for-each>
                                        </tr>
                                    </xsl:for-each>

                                    </tbody>

                                    </table>
                                </xsl:for-each>
                            <xsl:variable name="currentDate" select="'19-02-18'"/>
                            <xsl:for-each select="curriculum/jobs/job">
                                <ul class="an-employment">
                                    <xsl:variable name="endDate" select="substring(enddate, 3, 8)"/>
                                    <li>
                                        <xsl:value-of select="substring(startdate, 3, 8)"/> al <xsl:if test=" $endDate = $currentDate">día de hoy </xsl:if> <xsl:value-of select="$endDate"/>
                                    </li>
                                    <li>
                                        <xsl:value-of select="company"/>
                                    </li>
                                    <li>
                                        <xsl:value-of select="position"/>
                                    </li>

                                </ul>
                            </xsl:for-each>

                        </div><!-- End grid item: right panel -->
                    </div><!-- END: Grid container -->
                </div>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
