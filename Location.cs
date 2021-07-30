namespace Chess{

public class Location{

    public Piece piece {get; set;}
    public int X {get; set;}
    public int y {get; set;}

    public Location(int currentX, int currentY){
        piece = new Piece();
        X = currentX;
        y = currentY;
        
    }

}
}
