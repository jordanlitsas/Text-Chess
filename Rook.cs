namespace Chess{

public class Rook : Piece{

    public Rook(Color color){
        type = PieceType.rook;
        this.color = color;
        ColorSpecificSymbol();
        Symbol += "R |  ";
    }
}


}