namespace Chess{

public class King : Piece{
    public bool isCastle = false;
    public bool castleCondition {get; set;}
    public King(Color color){
        type = PieceType.king;
        this.color = color;
        ColorSpecificSymbol();
     

        Symbol += "X |  ";
    }
}


}