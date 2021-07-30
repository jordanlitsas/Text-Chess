namespace Chess{

public  class Piece{

    public string Symbol {get; set;}
    public Color color {get; set;}
    public PieceType type {get; set;}
    public int MoveCounter;

    public Piece(){
        type = PieceType.empty;
        MoveCounter = 0;
        color = Color.neutral;
        ColorSpecificSymbol();
        Symbol += "  | .. |  ";

    }

    protected void ColorSpecificSymbol(){
        if (color == Color.black){
            Symbol = "  | b";
        }
        if (color == Color.white){
            Symbol = "  | w";
        }
    }

    public enum Color{
        black, 
        white,
        neutral
    }

    public enum PieceType{
        empty,
        pawn,
        rook,
        bishop,
        knight,
        queen,
        king
    }


}

}