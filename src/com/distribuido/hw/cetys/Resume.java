package com.distribuido.hw.cetys;

import javax.xml.bind.annotation.*;
import java.util.ArrayList;

@XmlRootElement(name = "Resume")
@XmlType(propOrder = { "fullName", "cellphone", "email", "photoUri", "birthplace", "address", "jobs" })
public class Resume {
    // I would like this enum in attribute of "type"

    private Email email;
    private String fullName;
    private String cellphone;
    private String photoUri;
    private String birthplace;
    private Address address;
    private ArrayList<Employment> jobs;

    //region <setters getters>

    @XmlElement(name = "FullName")
    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    @XmlElement(name = "Cellphone")
    public String getCellphone() {
        return cellphone;
    }

    public void setCellphone(String cellphone) {
        this.cellphone = cellphone;
    }

    @XmlElement(name = "Email")
    public Email getEmail() {
        return email;
    }

    public void setEmail(Email email) {
        this.email = email;
    }

    @XmlElement(name = "PhotoUri")
    public String getPhotoUri() {
        return photoUri;
    }

    public void setPhotoUri(String photoUri) {
        this.photoUri = photoUri;
    }

    @XmlElement(name = "Birthplace")
    public String getBirthplace() {
        return birthplace;
    }

    public void setBirthplace(String birthplace) {
        this.birthplace = birthplace;
    }

    @XmlElement(name = "Address")
    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    @XmlElementWrapper(name = "Employments")
    @XmlElement(name = "Employment")
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
                ", photoUri='" + photoUri + '\'' +
                ", birthplace='" + birthplace + '\'' +
                ", address=" + address +
                ", jobs=" + jobs +
                '}';
    }
}

/*Curriculum
nombre
telefono
email
photo
lugar nacimiento
direccion: address
empleos : list < empleos> */