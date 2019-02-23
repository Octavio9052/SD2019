package com.distribuido.hw.cetys;

import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

@XmlRootElement(name = DtdConstants.ADDRESS)
@XmlType(propOrder = { "street", "number" ,"city", "state", "zipCode"})
public class Address {
    private String street;
    private String number;
    private String city;
    private String zipCode;
    private String state;

    public Address(){

    }

    public Address(String street, String number, String city, String state, String zipcode) {
        this.street = street;
        this.number = number;
        this.city = city;
        this.state = state;
        this.zipCode = zipcode;
    }

    @Override
    public String toString() {
        return "Address{" +
                "street='" + street + '\'' +
                ", number='" + number + '\'' +
                ", city='" + city + '\'' +
                ", state='" + state + '\'' +
                ", zipcode='" + zipCode + '\'' +
                '}';
    }

    @XmlElement(name = DtdConstants.STREET)
    public String getStreet() {
        return street;
    }

    public void setStreet(String street) {
        this.street = street;
    }

    @XmlElement(name = DtdConstants.NUMBER)
    public String getNumber() {
        return number;
    }

    public void setNumber(String number) {
        this.number = number;
    }

    @XmlElement(name = DtdConstants.ZIP_CODE)
    public String getZipCode() {
        return zipCode;
    }

    public void setZipCode(String zipCode) {
        this.zipCode = zipCode;
    }

    @XmlElement(name = DtdConstants.STATE)
    public String getState() {
        return state;
    }

    public void setState(String state) {
        this.state = state;
    }

    @XmlElement(name = DtdConstants.CITY)
    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }
}