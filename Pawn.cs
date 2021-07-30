namespace Chess{

public class Pawn : Piece{

    public Pawn(Color color){
        type = PieceType.pawn;
        this.color = color;
        ColorSpecificSymbol();

        Symbol += "p |  ";
    }

}


}