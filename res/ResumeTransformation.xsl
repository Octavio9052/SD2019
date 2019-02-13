<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html>
<head>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"></link>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.0/css/bootstrap.min.css" integrity="sha384-PDle/QlgIONtM1aqA2Qemk5gPOE7wFq8+Em+G/hmo5Iq0CCmYZLv3fVRDJ4MMwEA" crossorigin="anonymous"></link>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.0/js/bootstrap.min.js" integrity="sha384-7aThvCh9TypR7fIc2HV4O/nFMVCBwyIUKL8XCtKE+8xgCgl/PQGuFsvShjr74PBp" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="style.css" type="text/css"/>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no"/>
    <meta charset="utf-8"/>
    <script src="https://maps.googleapis.com/maps/api/js?key= AIzaSyCVXo3jVyaGAUZuplsrYurACV7cfz7fJgI"/>
    <script src="gmap.js">
        <xsl:attribute name="query"><xsl:value-of select="Resume/Address/Street"/> <xsl:value-of select="Resume/Address/Number"/>, <xsl:value-of select="Resume/Address/County"/>, <xsl:value-of select="Resume/Address/City"/>
        </xsl:attribute>
    </script> 
</head>
<body>
<div>
    <div class="grid-container">
        <div id="left-panel" class="grid-item">
            <div>
            <img id="profile"><xsl:attribute name="src">data:image/gif;base64,<xsl:value-of select="Resume/Photo"/></xsl:attribute></img>
                <div>
                    <h5>
                        <span id="txtBp">Lugar de nacimiento:</span>
                    </h5>
                    <div>
                        <xsl:value-of select="Resume/Birthplace"/>
                    </div>
                    <div class="alert alert-dark" role="alert">
                        <a href="#" id="bar-contact" class="alert-link">CONTACTO</a>
                    </div>
                    <div class="grid-container">
                        <div class="grid-item">
                            <div class="d-flex justify-content-center"><i class="material-icons">phone</i></div>
                            <div class="d-flex justify-content-center">Número celular</div>
                            <div class="d-flex justify-content-center"><xsl:value-of select="Resume/Cellphone"/></div>
                        </div>
                        <div id="email-data grid-item">
                            <xsl:variable name="typeEmail" select="Resume/Email/@type"/>
                            <xsl:choose>
                                <xsl:when test="$typeEmail = 'personal'"><div class="d-flex justify-content-center"><i class="material-icons md-96 md-dark">face</i></div><div class="d-flex justify-content-center">Email personal</div></xsl:when>
                                <xsl:when test="$typeEmail = 'work'"><div class="d-flex justify-content-center"><i class="material-icons md-96 md-dark">work</i></div><div class="d-flex justify-content-center">Email laboral</div></xsl:when>
                                <xsl:otherwise><div class="d-flex justify-content-center"><i class="material-icons md-96 md-dark">indeterminate_check_box</i></div><div class="d-flex justify-content-center">Email</div></xsl:otherwise>
                            </xsl:choose>
                            <div class="d-flex justify-content-center"><i class="material-icons"></i><xsl:value-of select="concat('',Resume/Email)"/>
                            </div>
                        </div>
                    </div>
                    <div class="alert alert-dark" role="alert">
                        <a href="#" id="bar-contact" class="alert-link">DIRECCIÓN</a>
                    </div>
                     <div id="address-data">
                            <xsl:value-of select="Resume/Address/Street"/>
                            <xsl:value-of select="Resume/Address/Number"/>
                            <xsl:value-of select="Resume/Address/County"/>
                            <xsl:value-of select="Resume/Address/City"/>
                    </div>
                </div>
            </div>
            <div id="map"/>
        </div>

    <div id="right-panel" class="grid-item">
    <xsl:value-of select="Resume/Name"/>
        <xsl:for-each select="Resume/Employments/Employment">
            <ul class="an-employment">
                <li>
                <xsl:value-of select="substring(StartDate, 3, 8)"/>
                </li>
                <li>
                <xsl:value-of select="substring(EndDate, 3, 8)"/>
                </li>
                <li>
                <xsl:value-of select="Company"/>
                </li>
                <li>
                <xsl:value-of select="Role"/>
                </li>
            </ul>
        </xsl:for-each>
    </div>
</div>
</div>
</body>
</html>
</xsl:template>
</xsl:stylesheet>