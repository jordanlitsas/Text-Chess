namespace Chess{

public class Knight : Piece{
    
    public Knight(Color color){
        type = PieceType.knight;
        this.color = color;
        ColorSpecificSymbol();
        Symbol += "K |  ";
    }
}


}