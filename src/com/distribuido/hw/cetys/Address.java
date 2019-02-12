package com.distribuido.hw.cetys;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

@XmlRootElement(name = "Address")
@XmlType(propOrder = { "street", "number", "county", "city" })
public class Address {
    private String street;
    private String number;
    private String county;
    private String city;

    public Address(){

    }

    public Address(String street, String number, String county, String city) {
        this.street = street;
        this.number = number;
        this.county = county;
        this.city = city;
    }

    @Override
    public String toString() {
        return "com.distribuido.hw.cetys.Address{" +
                "street='" + street + '\'' +
                ", number='" + number + '\'' +
                ", county='" + county + '\'' +
                ", city='" + city + '\'' +
                '}';
    }

    @XmlElement(name = "Street")
    public String getStreet() {
        return street;
    }

    public void setStreet(String street) {
        this.street = street;
    }

    @XmlElement(name = "OutsideNumber")
    public String getNumber() {
        return number;
    }

    public void setNumber(String number) {
        this.number = number;
    }

    @XmlElement(name = "County")
    public String getCounty() {
        return county;
    }

    public void setCounty(String county) {
        this.county = county;
    }

    @XmlElement(name = "City")
    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }
}