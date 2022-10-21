namespace fids_backend.Models;

public class Pagination
{
    public int currentPageIndex { get; set; }
    public int pageCount { get; set; }
    public List <FlightDetail> flightDetailsList { get; set; }
}