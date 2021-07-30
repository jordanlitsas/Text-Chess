namespace Chess{

public class Bishop : Piece{

    public Bishop(Color color){
        type = PieceType.bishop;
        this.color = color;
        ColorSpecificSymbol();

        Symbol += "B |  ";
    }
}


}