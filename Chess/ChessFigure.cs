
using System;

namespace Chess
{	
	public abstract class ChessFigure
    {
		protected Coordinate CurrentCoordinate { get; } = new Coordinate();
		protected Coordinate NextCoordinate { get; private set; } = new Coordinate();

		public ChessFigure(string currentCoordinate)
		{
			CurrentCoordinate.Load(currentCoordinate);
		}

		public virtual bool Move(string nextCoordinate)
        {
			NextCoordinate = new Coordinate(nextCoordinate);

			return true;
		}
	}

    public class Rook : ChessFigure
    {
		public Rook(string currentCoordinate)
			: base(currentCoordinate)
        {
        }

        public override bool Move(string nextCoordinate)
        {
			base.Move(nextCoordinate);

			return (NextCoordinate.Column != CurrentCoordinate.Column) && (NextCoordinate.Row == CurrentCoordinate.Row) || ((NextCoordinate.Column == CurrentCoordinate.Column) && (NextCoordinate.Row != CurrentCoordinate.Row));
		}
	}

    public class Knight : ChessFigure
    {
		public Knight(string currentCoordinate)
			: base(currentCoordinate)
		{
		}

		public override bool Move(string nextCoordinate)
        {
			base.Move(nextCoordinate);

			var dx = Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column);
			var dy = Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row);

			return dx == 1 && dy == 2 || dx == 2 && dy == 1;
		}
	}

    public class Bishop : ChessFigure
    {
		public Bishop(string currentCoordinate)
			: base(currentCoordinate)
		{
		}

		public override bool Move(string nextCoordinate)
        {
			base.Move(nextCoordinate);

			return Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column) == Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row);
		}
	}

    public class Pawn : ChessFigure
    {
		public Pawn(string currentCoordinate)
			: base(currentCoordinate)
		{
		}

		public override bool Move(string nextCoordinate)
        {
			base.Move(nextCoordinate);

			return !(NextCoordinate.Column != CurrentCoordinate.Column || NextCoordinate.Row <= CurrentCoordinate.Row || (NextCoordinate.Row - CurrentCoordinate.Row != 1 && (CurrentCoordinate.Row != 2 || NextCoordinate.Row != 4)));
		}
	}

    public class King : ChessFigure
    {
		public King(string currentCoordinate)
			: base(currentCoordinate)
		{
		}

		public override bool Move(string nextCoordinate)
        {
			base.Move(nextCoordinate);

			return Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column) <= 1 && Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row) <= 1;
		}
	}

    public class Queen : ChessFigure
    {
		public Queen(string currentCoordinate)
			: base(currentCoordinate)
		{
		}

		public override bool Move(string nextCoordinate)
        {
			base.Move(nextCoordinate);

			return Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column) == Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row) || NextCoordinate.Column == CurrentCoordinate.Column || NextCoordinate.Row == CurrentCoordinate.Row;
		}
	}
}
