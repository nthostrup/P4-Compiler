﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parserproject
{
    public class Interpreter : IVisitor
    {
        public Symboltable<Expression> env = new Symboltable<Expression>();

        public void Interpret(AST ast)
        {
            visit(ast.Root);

            env.Print();
        }

        private Expression Apply(ConstantExpression c, Expression exp)
        {
            if (exp.Value is ValueExpression || exp.Value is EmptyListExpression)
            {
                if (c is PlusConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new PlusConstN(valExp);
                }
                else if (c is PlusConstN) {
                    PlusConstN constExp = c as PlusConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType || valExp.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);

                        return new ValueExpression((n + m).ToString(), new TalType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);

                        return new ValueExpression((n + m).ToString(), new HeltalType());
                    }
                }
                else if (c is MinusConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new MinusConstN(valExp);
                }
                else if (c is MinusConstN) {
                    MinusConstN constExp = c as MinusConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType || valExp.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);

                        return new ValueExpression((n - m).ToString(), new TalType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);

                        return new ValueExpression((n - m).ToString(), new HeltalType());
                    }
                }
                else if (c is TimesConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new TimesConstN(valExp);
                }
                else if (c is TimesConstN) {
                    TimesConstN constExp = c as TimesConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType || valExp.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);

                        return new ValueExpression((n * m).ToString(), new TalType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);

                        return new ValueExpression((n * m).ToString(), new HeltalType());
                    }
                }
                else if (c is DivideConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new DivideConstN(valExp);
                }
                else if (c is DivideConstN) {
                    DivideConstN constExp = c as DivideConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType || valExp.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);

                        return new ValueExpression((n / m).ToString(), new TalType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);

                        return new ValueExpression((n / m).ToString(), new HeltalType());
                    }
                }
                else if (c is PotensConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new PotensConstN(valExp);
                }
                else if (c is PotensConstN) {
                    PotensConstN constExp = c as PotensConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType || valExp.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);

                        return new ValueExpression((Math.Pow(n, m)).ToString(), new TalType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);

                        return new ValueExpression((Math.Pow(n, m)).ToString(), new HeltalType());
                    }
                }
                else if (c is ModuloConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new ModuloConstN(valExp);
                }
                else if (c is ModuloConstN) {
                    ModuloConstN constExp = c as ModuloConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType || valExp.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);

                        return new ValueExpression((n % m).ToString(), new TalType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);

                        return new ValueExpression((n % m).ToString(), new HeltalType());
                    }
                }
                else if (c is EqualConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new EqualConstN(valExp);
                }
                else if (c is EqualConstN) {
                    EqualConstN constExp = c as EqualConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is BoolType && valExp.Type is BoolType) {
                        bool n = bool.Parse(constExp.Nval.val);
                        bool m = bool.Parse(valExp.val);
                        string truthvalue = n == m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                    else if (constExp.Nval.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);
                        string truthvalue = n == m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);
                        string truthvalue = n == m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                }

                else if (c is NotEqualConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new EqualConstN(valExp);
                }
                else if (c is NotEqualConstN) {
                    NotEqualConstN constExp = c as NotEqualConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is BoolType && valExp.Type is BoolType) {
                        bool n = bool.Parse(constExp.Nval.val);
                        bool m = bool.Parse(valExp.val);
                        string truthvalue = n != m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                    else if (constExp.Nval.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);
                        string truthvalue = n != m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);
                        string truthvalue = n != m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                }

                else if (c is LesserThanConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new LesserThanConstN(valExp);
                }
                else if (c is LesserThanConstN) {
                    LesserThanConstN constExp = c as LesserThanConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);
                        string truthvalue = n < m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);
                        string truthvalue = n < m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                }
                else if (c is LesserThanOrEqualConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new LesserThanOrEqualConstN(valExp);
                }
                else if (c is LesserThanOrEqualConstN) {
                    LesserThanOrEqualConstN constExp = c as LesserThanOrEqualConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);
                        string truthvalue = n <= m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);
                        string truthvalue = n <= m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                }
                else if (c is GreaterThanConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new GreaterThanConstN(valExp);
                }
                else if (c is GreaterThanConstN) {
                    GreaterThanConstN constExp = c as GreaterThanConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);
                        string truthvalue = n > m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);
                        string truthvalue = n > m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                }
                else if (c is GreaterThanOrEqualConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new GreaterThanOrEqualConstN(valExp);
                }
                else if (c is GreaterThanOrEqualConstN) {
                    GreaterThanOrEqualConstN constExp = c as GreaterThanOrEqualConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    if (constExp.Nval.Type is TalType) {
                        double n = double.Parse(constExp.Nval.val);
                        double m = double.Parse(valExp.val);
                        string truthvalue = n >= m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                    else {
                        int n = int.Parse(constExp.Nval.val);
                        int m = int.Parse(valExp.val);
                        string truthvalue = n >= m ? "sand" : "falsk";

                        return new ValueExpression(truthvalue, new BoolType());
                    }
                }
                else if (c is PairConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new PairConstN(valExp);
                }
                else if (c is PairConstN) {
                    PairConstN constExp = c as PairConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    return new ValueExpression(Tuple.Create(constExp.exp.Value, valExp.val).ToString(), new TupleType());
                }
                else if (c is ListConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new ListConstN(valExp);
                }

                else if (c is ListConstN) {
                    ListConstN constExp = c as ListConstN;
                    List<string> list = new List<string>();

                    if (exp.Value is ValueExpression) {
                        ValueExpression valExp = exp.Value as ValueExpression;

                        list.Add(constExp.exp.Value.ToString());
                        list.AddRange(valExp.vals);
                        return new ValueExpression(list, TokenType.datatype);
                    }
                    else {
                        list.Add(constExp.exp.Value.ToString());

                        return new ValueExpression(list, TokenType.datatype);
                    }
                }
                else if(c is ConcatConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    return new ConcatConstN(valExp);
                }
                else if(c is ConcatConstN) {
                    ConcatConstN constExp = c as ConcatConstN;
                    List<string> list = new List<string>();

                    if (exp.Value is ValueExpression) {
                        ValueExpression valExp = exp.Value as ValueExpression;

                        list.AddRange(constExp.Nval.vals);
                        list.AddRange(valExp.vals);
                        return new ValueExpression(list, TokenType.datatype);
                    }
                    else {
                        return new ValueExpression(list, TokenType.datatype);
                    }
                }

                else if (c is NotConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;

                    string truthvalue = valExp.val == "sand" ? "falsk" : "sand";

                    return new ValueExpression(truthvalue, new BoolType());
                }
                else if (c is HeadConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;
                    
                    return new ValueExpression(valExp.vals.First(), valExp.Type); //TODO sufficient type
                }
                else if (c is TailConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;

                    
                    return new ValueExpression(valExp.vals.GetRange(1, valExp.vals.Count - 1), TokenType.datatype);
                }
                else if (c is AndConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;

                    return new AndConstN(valExp);
                }
                else if (c is AndConstN) {
                    AndConstN constExp = c as AndConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    bool n = constExp.Nval.val == "sand" ? true : false;
                    bool m = valExp.val == "sand" ? true : false;

                    string truthvalue = n && m ? "sand" : "falsk";

                    return new ValueExpression(truthvalue, new BoolType());
                }

                else if (c is OrConst) {
                    ValueExpression valExp = exp.Value as ValueExpression;

                    return new OrConstN(valExp);
                }
                else if (c is OrConstN) {
                    OrConstN constExp = c as OrConstN;
                    ValueExpression valExp = exp.Value as ValueExpression;

                    bool n = constExp.Nval.val == "sand" ? true : false;
                    bool m = valExp.val == "sand" ? true : false;
                    string truthvalue = n || m ? "sand" : "falsk";

                    return new ValueExpression(truthvalue, new BoolType());
                }

                else { throw new Exception("no!"); }
            }
            else if (exp.Value is EmptyListExpression)
            {
                return exp;
            }
            else { throw new Exception("no!"); }
        }

        public void visit(ASTNode node)
        {
            node.accept(this);
        }

        public void visit(EmptyDecl node)
        {
            
        }

        public void visit(IfExpression node)
        {

            // if1
            // hvis node.condition er et udtryk, reducer condition

            //if2
            // hvis node.condition = sand reducer node.alt1

            //if3
            // hvis node.condition = falsk reducer node.alt1
            visit(node.condition);

            bool truth;

            // TODO clean up + handle exceptions

            object val = node.condition.Value;
            ValueExpression valexp = val as ValueExpression;
            string valString = valexp.val;

            truth = valString == "sand";
            
            if (truth)
            {
                visit(node.alt1);
                node.Value = node.alt1.Value;
            }
            else
            {
                visit(node.alt2);
                node.Value = node.alt2.Value;
            }
        }

        public void visit(AnonFuncExpression node)
        {
            // er sin egen værdi (fingers crossed)
            node.Value = node;
        }

        public void visit(EmptyListExpression node)
        {
            node.Value = node;
        }

        public void visit(PairConst node)
        {
            node.Value = node;
        }

        public void visit(MinusConst node)
        {
            node.Value = node;
        }

        public void visit(PlusConst node)
        {
            node.Value = node;
        }

        public void visit(TimesConst node)
        {
            node.Value = node;
        }

        public void visit(DivideConst node)
        {
            node.Value = node;
        }

        public void visit(PotensConst node)
        {
            node.Value = node;
        }

        public void visit(ListConst node)
        {
            node.Value = node;
        }

        public void visit(ClosureExpression node)
        {
            throw new NotImplementedException();
        }

        public void visit(IdentifierExpression node)
        {
            node.Value = env.LookUp(node.varName);
        }

        public void visit(EmptyExpression node)
        {
            node.Value = node;
        }

        public void visit(ApplicationExpression node)
        {
            visit(node.argument); //app1
            visit(node.function); //app2

            if (node.function.Value is ConstantExpression) // hvis funk er const
            {
                ConstantExpression c = node.function.Value as ConstantExpression;
                node.Value = Apply(c, node.argument);
            }
            else if(node.function.Value is AnonFuncExpression) // hvis funk er Anonfunk
            {
                AnonFuncExpression function = node.function.Value as AnonFuncExpression;

                env.Add(function.arg.token.content, node.argument.Value);
                visit(function.exp);
                node.Value = function.exp.Value;
                env.Remove();
            }
            else
            {
                throw new Exception("SHit!");
            }
        }

        public void visit(ValueExpression node)
        {
            node.Value = node;
        }

        public void visit(LetExpression node)
        {
            //[LET1]
            visit(node.exp1);

            //[LET2]
            env.Add(node.id.token.content, node.exp1.Value);
            visit(node.exp2);
            node.Value = node.exp2.Value;
            env.Remove();
        }

        public void visit(VarDecl node)
        {
            visit(node.exp);
            env.Add(node.id.token.content, node.exp.Value);
            visit(node.nextDecl);
        }

        public void visit(ProgramAST node)
        {
            visit(node.varDecl);
            visit(node.exp);
        }

        public void visit(ConstantFuncs node)
        {

        }

        public void visit(ModuloConst node)
        {
            node.Value = node;
        }

        public void visit(EqualConst node)
        {
            node.Value = node;
        }

        public void visit(NotEqualConst node)
        {
            node.Value = node;
        }

        public void visit(LesserThanConst node)
        {
            node.Value = node;
        }

        public void visit(GreaterThanConst node)
        {
            node.Value = node;
        }

        public void visit(GreaterThanOrEqualConst node)
        {
            node.Value = node;
        }

        public void visit(LesserThanOrEqualConst node)
        {
            node.Value = node;
        }

        public void visit(NotConst node)
        {
            node.Value = node;
        }

        public void visit(HeadConst node) {
            node.Value = node;
        }

        public void visit(TailConst node) {
            node.Value = node;
        }

        public void visit(OrConst node) {
            node.Value = node;
        }

        public void visit(AndConst node) {
            node.Value = node;
        }

        public void visit(ConcatConst node) {
            node.Value = node;
        }
        /*
public void visit(ConcatConst node)
{
node.Value = node;
}
*/
    }
}
