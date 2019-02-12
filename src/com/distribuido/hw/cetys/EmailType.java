package com.distribuido.hw.cetys;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;

@XmlType
@XmlEnum(String.class)
public enum EmailType {
  @XmlEnumValue("personal")
  PERSONAL, @XmlEnumValue("work")
  WORK, @XmlEnumValue("other")
  OTHER
}
