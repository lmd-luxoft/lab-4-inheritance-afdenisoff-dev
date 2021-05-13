
using System;

namespace Chess
{	
	public class Coordinate
    {
		public char Column { get; }
		public int Row { get; }

		public Coordinate() 
		{ 
		}

		public Coordinate(string coordinate)
        {
			Load(coordinate);
        }

		public void Load(string coordinate)
		{
            if (!IsValid(coordinate))
            {
				throw new ArgumentException();
            }

		}

		private bool IsValid(string coordinate)
        {
			return true;
        }
    }

	public abstract class ChessFigure
    {
		protected const int firstRowCoordinate = 1;
		protected const int lastRowCoordinate = 8;
		protected const char firstColumnCoordinate = 'A';
		protected const char lastColumnCoordinate = 'H';

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

			if ((NextCoordinate.Column != CurrentCoordinate.Column) && (NextCoordinate.Row != CurrentCoordinate.Row) || ((NextCoordinate.Column == CurrentCoordinate.Column) && (NextCoordinate.Row == CurrentCoordinate.Row)))
				return false;
			else
				return true;
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

			int dx, dy;
			dx = Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column);
			dy = Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row);
			if (!(Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column) == 1 && Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row) == 2 || Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column) == 2 && Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row) == 1))
				return false;
			else
				return true;
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

			if (!(Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column) == Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row)))
				return false;
			else
				return true;
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

			if (NextCoordinate.Column != CurrentCoordinate.Column || NextCoordinate.Row <= CurrentCoordinate.Row || (NextCoordinate.Row - CurrentCoordinate.Row != 1 && (CurrentCoordinate.Row != 2 || NextCoordinate.Row != 4)))
				return false;
			else
				return true;
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

			if (!(Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column) <= 1 && Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row) <= 1))
				return false;
			else
				return true;
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

			if (!(Math.Abs(NextCoordinate.Column - CurrentCoordinate.Column) == Math.Abs(NextCoordinate.Row - CurrentCoordinate.Row) || NextCoordinate.Column == CurrentCoordinate.Column || NextCoordinate.Row == CurrentCoordinate.Row))
				return false;
			else
				return true;
		}
	}
}
