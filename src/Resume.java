import java.util.ArrayList;
import java.util.List;

public class Resume {
    private String fullName;
    private String cellphone;
    private String email;
    private String photoUri;
    private String birthplace;
    private Address address;
    private ArrayList<Employment> jobs;

    //region <setters getters>
    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getCellphone() {
        return cellphone;
    }

    public void setCellphone(String cellphone) {
        this.cellphone = cellphone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPhotoUri() {
        return photoUri;
    }

    public void setPhotoUri(String photoUri) {
        this.photoUri = photoUri;
    }

    public String getBirthplace() {
        return birthplace;
    }

    public void setBirthplace(String birthplace) {
        this.birthplace = birthplace;
    }

    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    public ArrayList<Employment> getJobs() {
        return jobs;
    }

    public void setJobs(ArrayList<Employment> jobs) {
        this.jobs = jobs;
    }
//endregion


    @Override
    public String toString() {
        return "Resume{" +
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