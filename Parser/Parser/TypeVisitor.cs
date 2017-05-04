﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parserproject
{
    public class TypeVisitor : IVisitor
    {
        public Dictionary<string, string> typeEnvironment = new Dictionary<string, string>();
        public Dictionary<string, string> sigmaConstants = new Dictionary<string, string>() {
            {"PLUS","heltal->heltal->heltal"},
            {"PLUS2","tal->heltal->tal" },
            {"MINUS","heltal->heltal->heltal"},
            {"MINUS2","tal->heltal->tal" },
            {"GANGE","heltal->heltal->heltal"},
            {"DIVIDER","heltal->heltal->heltal"},
            {"MODULUS","heltal->heltal->heltal"},
            {"POTENS","heltal->heltal->heltal"},
            {"NOT","bool->bool"},
            {"OG","bool->bool->bool"},
            {"ELLER","bool->bool->bool"},
            {"STØRRE","heltal->heltal->bool"},
            {"MINDRE","heltal->heltal->bool"},
            {"STØRREELLERLIGMED","heltal->heltal->bool"},
            {"MINDREELLERLIGMED","heltal->heltal->bool"},
            {"LIGMED","heltal->heltal->bool"},
            {"PAR","a->b->a*b"},//Better placeholder.
            {"LISTE","a->{a}->{a}"}//Better placeholder.
        };

        public void visit(Node node) {
            throw new NotImplementedException();
        }

        public void visit(Operator node) {
            node.type = node.token.Type;
        }

        public void visit(Value node) {
            node.type = node.token.Type;
        }

        public void visit(Decl node) {
            foreach (var n in node.Children)
                n.accept(this);

            node.type = node.Children[0].type;
            
        }

        public void visit(SeqDecl node) {
            foreach (var n in node.Children)
                n.accept(this);

            node.type = node.Children[0].type;
        }

        public void visit(TypeDecl node) {
            foreach (var n in node.Children)
                n.accept(this);

            node.type = TokenType.datatype;
        }

        public void visit(DatatypeLabelPair node) {
            foreach (var n in node.Children)
                n.accept(this);

            node.type = node.elementType.token.Type;
        }

        public void visit(DefaultClause node) {
            throw new NotImplementedException();
        }

        public void visit(Expression node) {
            foreach (var n in node.Children)
                n.accept(this);
            throw new NotImplementedException();
        }

        public void visit(OperatorExpression node) {

            foreach (var child in node.Children) {
                child.accept(this);
            }

            if (node.Children[0].type == TokenType.op) {
                Operator op = (Operator)node.Children[0];

                switch (op.token.content) {
                    case "-":
                    case "+":
                    case "*":
                    case "/":
                    case "^":
                    case "%":
                        node.type = generalize(node.Children[1].type, node.Children[2].type);
                        break;
                    case "<":
                    case "<=":
                    case ">":
                    case ">=":
                    case "==":
                    case "!=":
                        if(node.Children[1].type == node.Children[2].type //TODO måske konverter/kompatibilitet mellem heltal/tal.
                           && ((node.Children[1].type == TokenType.heltal) || (node.Children[1].type == TokenType.tal) || node.Children[1].type == TokenType.streng)) {
                            
                            node.type = TokenType.boolean;
                        }
                        else {
                            throw new Exception("");
                        }
                        break;
                    case "&&":
                    case "||":
                        if ((node.Children[1].type != TokenType.boolean || node.Children[2].type != TokenType.boolean)) {
                            throw new Exception("Both nodes must be of type boolean");
                        }
                        node.type = TokenType.boolean;
                        break;
                    case "!":
                        if(node.Children[1].type != TokenType.boolean) {
                            throw new Exception("Must be boolean to negate");
                        }
                        node.type = TokenType.boolean;
                        break;
                    case ".":
                        if(node.Children[1].type != TokenType.datatype) {
                            throw new Exception("Expected type: datatype");
                        }
                        node.type = TokenType.datatype;
                        //TODO MORE 
                        break;
                    case ":":
                        //TODO
                        node.type = 0; 
                        break;
                    default:
                        throw new Exception("Operator not recognized");
                }
                
            }            
        }

        public void visit(LetExpression node) {
            throw new NotImplementedException();
        }

        public void visit(ValueExpression node) {
            foreach (var n in node.Children)
                n.accept(this);

            //Made possible to exchange to string. //Should maybe be moved to Value visit?
            Value v = (Value)node.Children[0];
            switch (v.type) {
                case TokenType.streng:
                    node.type = (TokenType)Enum.Parse(typeof(TokenType), sigmaConstants["STRENG"]); //TODO MISSING IN SHARELATEX+DICTIONARY
                    break;
                case TokenType.heltal:
                    node.type = (TokenType)Enum.Parse(typeof(TokenType), sigmaConstants["HELTAL"]);//TODO MISSING IN SHARELATEX+DICTIONARY
                    break;
                case TokenType.tal:
                    node.type = (TokenType)Enum.Parse(typeof(TokenType), sigmaConstants["TAL"]);//TODO MISSING IN SHARELATEX+DICTIONARY
                    break;
                case TokenType.boolean:
                    node.type = (TokenType)Enum.Parse(typeof(TokenType), sigmaConstants["BOOL"]);//TODO MISSING IN SHARELATEX+DICTIONARY
                    break;
                case TokenType.keyword:
                    node.type = (TokenType)Enum.Parse(typeof(TokenType), sigmaConstants["KEYWORD"]);//TODO MISSING IN SHARELATEX+DICTIONARY
                    break;
                case TokenType.decl:
                    break;
                case TokenType.typeDecl:
                    break;
                case TokenType.op:
                    break;
                case TokenType.parentes:
                    break;
                case TokenType.seperator:
                    break;
                case TokenType.EOF:
                    break;
                default:
                    throw new Exception("Type of value not found for: "+ v.type);
            }
            


             
        }

        public void visit(StructureExpression node) {
            throw new NotImplementedException();
        }

        public void visit(TupleExpression node) {
            throw new NotImplementedException();
        }

        public void visit(EmptyExpression node) {
            throw new NotImplementedException();
        }

        public void visit(ApplicationExpression node) {
            throw new NotImplementedException();
        }

        public void visit(ListExpression node) {
            throw new NotImplementedException();
        }

        public void visit(IdentifierExpression node) {
            throw new NotImplementedException();
        }

        public void visit(AnonFuncExpression node) {
            throw new NotImplementedException();
        }

        public void visit(IfExpression node) {
            throw new NotImplementedException();
        }

        public void visit(ConstrExpression node) {
            throw new NotImplementedException();
        }

        public void visit(ConditionalClause node) {
            throw new NotImplementedException();
        }

        public void visit(Clause node) {
            throw new NotImplementedException();
        }

        public void visit(EmptyDecl node) {
            throw new NotImplementedException();
        }

        public void visit(FuncDecl node) {
            throw new NotImplementedException();
        }

        public void visit(VarDecl node) {
            foreach (var child in node.Children) {
                child.accept(this);
            }
            Identifier id = (Identifier)node.Children[0];
            Expression exp = (Expression)node.Children[1];
            if (!typeEnvironment.ContainsKey(id.token.content)) {
                typeEnvironment.Add(id.token.content, exp.type.ToString());//An example/idea to add to typeenvironment (casting type to string.)
            }
            else {
                throw new Exception("Variable already declared of type: " + typeEnvironment[id.token.content]);
            }
        }

        public void visit(ProgramAST node) {
            throw new NotImplementedException();
        }

        public void visit(Constructor node) {
            node.type = node.token.Type;
        }

        public void visit(Identifier node) {
            Tuple<string, string> id;

            if (AST.table.TryGetValue(node.token.content, out id))//Table from parsing
                node.type = (TokenType)Enum.Parse(typeof(TokenType), id.Item1); //Lookup for type of identifier in enum
            else
                throw new Exception("Identifier not found in symboltable");
        }

        public void visit(Leaf leaf) {
            Tuple<string, string> id;

            if (AST.table.TryGetValue(leaf.token.content, out id))
                leaf.type = (TokenType)Enum.Parse(typeof(TokenType), id.Item1); //Lookup for type of identifier in enum
            else
                leaf.type = leaf.token.Type;
        }

        public void visit(ASTNode node) {
            throw new NotImplementedException();
        }


        private TokenType generalize(TokenType t1, TokenType t2) {
            if (! (t1 == TokenType.tal || t1 == TokenType.heltal) && (t2 == TokenType.tal || t2 == TokenType.heltal)) {
                throw new Exception("Types not compatible");
            }

            if (t1 == TokenType.tal || t2 == TokenType.tal) {
                return TokenType.tal;
            }
            else {
                return TokenType.heltal;
            }
        }
    }
}
