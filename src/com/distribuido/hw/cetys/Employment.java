package com.distribuido.hw.cetys;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import java.util.Date;

@XmlRootElement(name = "Employment")
@XmlType(propOrder = { "startDate", "endDate", "company", "jobRole" })
public class Employment {
    private Date startDate;
    private Date endDate;
    private String company;
    private String jobRole;

    public Employment(){

    }

    public Employment(Date startDate, Date endDate, String company, String jobRole) {
        this.startDate = startDate;
        this.endDate = endDate;
        this.company = company;
        this.jobRole = jobRole;
    }

    @Override
    public String toString() {
        return "com.distribuido.hw.cetys.Employment{" +
                "startDate='" + startDate + '\'' +
                ", endDate='" + endDate + '\'' +
                ", company='" + company + '\'' +
                ", jobRole='" + jobRole + '\'' +
                '}';
    }

    @XmlElement(name = "StartDate")
    public Date getStartDate() {
        return startDate;
    }

    public void setStartDate(Date startDate) {
        this.startDate = startDate;
    }

    @XmlElement(name = "EndDate")
    public Date getEndDate() {
        return endDate;
    }

    public void setEndDate(Date endDate) {
        this.endDate = endDate;
    }

    @XmlElement(name = "Company")
    public String getCompany() {
        return company;
    }

    public void setCompany(String company) {
        this.company = company;
    }

    @XmlElement(name = "Role")
    public String getJobRole() {
        return jobRole;
    }

    public void setJobRole(String jobRole) {
        this.jobRole = jobRole;
    }
}