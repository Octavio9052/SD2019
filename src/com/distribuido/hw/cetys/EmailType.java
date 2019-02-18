package com.distribuido.hw.cetys;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;

@XmlType
@XmlEnum(String.class)
public enum EmailType {
  @XmlEnumValue(DtdConstants.EMAIL_ATT1_OPTION_1)
  PERSONAL, @XmlEnumValue(DtdConstants.EMAIL_ATT1_OPTION_2)
  WORK, @XmlEnumValue(DtdConstants.EMAIL_ATT1_OPTION_3)
  OTHER
}
