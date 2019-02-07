import java.util.Date;

public class Employment {
    private String startDate;
    private String endDate;
    private String company;
    private String jobRole;

    public Employment(String startDate, String endDate, String company, String jobRole) {
        this.startDate = startDate;
        this.endDate = endDate;
        this.company = company;
        this.jobRole = jobRole;
    }

    @Override
    public String toString() {
        return "Employment{" +
                "startDate='" + startDate + '\'' +
                ", endDate='" + endDate + '\'' +
                ", company='" + company + '\'' +
                ", jobRole='" + jobRole + '\'' +
                '}';
    }

    public String getStartDate() {
        return startDate;
    }

    public void setStartDate(String startDate) {
        this.startDate = startDate;
    }

    public String getEndDate() {
        return endDate;
    }

    public void setEndDate(String endDate) {
        this.endDate = endDate;
    }

    public String getCompany() {
        return company;
    }

    public void setCompany(String company) {
        this.company = company;
    }

    public String getJobRole() {
        return jobRole;
    }

    public void setJobRole(String jobRole) {
        this.jobRole = jobRole;
    }
}