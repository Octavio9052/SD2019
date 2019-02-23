package com.distribuido.hw.cetys;

import javax.xml.bind.annotation.*;
import java.awt.*;
import java.util.ArrayList;

@XmlRootElement(name = DtdConstants.ROOT_NAME)
@XmlType(propOrder = { "fullName", "cellphone", "birthplace", "email", "photo", "address", "jobs"})
public class Resume {
    private Email email;
    private String fullName;
    private String cellphone;
    private Image photo;
    private String birthplace;
    private Address address;
    private ArrayList<Employment> jobs;
    @XmlAttribute(name = "xmlns:xsi")
    private static final String xschemaDeclaration = "http://www.w3.org/2001/XMLSchema-instance";
    @XmlAttribute(name = "xsi:noNamespaceSchemaLocation")
    private static final String xsLocation = "curriculum.xsd";

    //region <setters getters>

    @XmlElement(name = DtdConstants.FULL_NAME)
    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    @XmlElement(name = DtdConstants.CELLPHONE)
    public String getCellphone() {
        return cellphone;
    }

    public void setCellphone(String cellphone) {
        this.cellphone = cellphone;
    }

    @XmlElement(name = DtdConstants.EMAIL)
    public Email getEmail() {
        return email;
    }

    public void setEmail(Email email) {
        this.email = email;
    }

    @XmlElement(name = DtdConstants.PHOTO)
    public Image getPhoto() {
        return photo;
    }

    public void setPhoto(Image photo) {
        this.photo = photo;
    }

    @XmlElement(name = DtdConstants.BIRTHPLACE)
    public String getBirthplace() {
        return birthplace;
    }

    public void setBirthplace(String birthplace) {
        this.birthplace = birthplace;
    }

    @XmlElement(name = DtdConstants.ADDRESS)
    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    @XmlElementWrapper(name = DtdConstants.EMPLOYMENTS)
    @XmlElement(name = DtdConstants.EMPLOYMENT)
    public ArrayList<Employment> getJobs() {
        return jobs;
    }

    public void setJobs(ArrayList<Employment> jobs) {
        this.jobs = jobs;
    }
//endregion


    @Override
    public String toString() {
        return "com.distribuido.hw.cetys.Resume{" +
                "fullName='" + fullName + '\'' +
                ", cellphone='" + cellphone + '\'' +
                ", email='" + email + '\'' +
                ", photo='" + photo + '\'' +
                ", birthplace='" + birthplace + '\'' +
                ", address=" + address +
                ", jobs=" + jobs +
                '}';
    }
}