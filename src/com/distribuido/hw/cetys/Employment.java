package com.distribuido.hw.cetys;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import java.util.Date;

@XmlRootElement(name = DtdConstants.EMPLOYMENTS)
@XmlType(propOrder = { "jobRole", "company", "startDate", "endDate" })
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

    @XmlElement(name = DtdConstants.START_DATE)
    public Date getStartDate() {
        return startDate;
    }

    public void setStartDate(Date startDate) {
        this.startDate = startDate;
    }

    @XmlElement(name = DtdConstants.END_DATE)
    public Date getEndDate() {
        return endDate;
    }

    public void setEndDate(Date endDate) {
        this.endDate = endDate;
    }

    @XmlElement(name = DtdConstants.COMPANY)
    public String getCompany() {
        return company;
    }

    public void setCompany(String company) {
        this.company = company;
    }

    @XmlElement(name = DtdConstants.POSITION)
    public String getJobRole() {
        return jobRole;
    }

    public void setJobRole(String jobRole) {
        this.jobRole = jobRole;
    }
}