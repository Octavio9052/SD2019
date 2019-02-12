package com.distribuido.hw.cetys;

import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlValue;

public class Email {
  private EmailType emailType;
  private String emailAddress;

  Email() {}
  Email(String emailAddress, EmailType emailType) {
    this.emailAddress = emailAddress;
    this.emailType = emailType;
  }

  @XmlAttribute(name = "type")
  public EmailType getEmailType() {
    return emailType;
  }

  public void setEmailType(EmailType emailType) {
    this.emailType = emailType;
  }

  @XmlValue
  public String getEmailAddress() {
    return emailAddress;
  }

  public void setEmailAddress(String emailAddress) {
    this.emailAddress = emailAddress;
  }
}
