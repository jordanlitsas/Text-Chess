namespace Chess{

public class Queen : Piece{
    
    public Queen(Color color){
        type = PieceType.queen;
        this.color = color;
        ColorSpecificSymbol();
        Symbol += "Q |  ";
    }
}


}