from re import S
from sqlalchemy import create_engine, Table, Column, Integer, String, MetaData, ForeignKey, DateTime, Text, BigInteger
from sqlalchemy.orm import mapper, sessionmaker
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.sql import default_comparator
import datetime
from sqlalchemy.ext.compiler import compiles
import os

BASE = declarative_base()

class Storage:

    class AccountMeta(BASE):

        __tablename__ = 'accountmeta'
        id = Column(Integer, primary_key=True)
        user_id = Column(Integer)
        name = Column(String, unique=True)
        amount = Column(Integer)
        frozen = Column(Integer)

        def __init__(self, login, password):
            self.id = None
            self.user_id = None
            self.name = None
            self.amount = None
            self.frozen = None

        def __repr__(self):
            return f'<UserContent({self.id}, {self.name}, {self.user_id}, {self.amount}, {self.frozen})>'


    class DocumentMeta(BASE):

        __tablename__ = 'documentmeta'
        id = Column(Integer, primary_key=True)
        type = Column(Integer)
        name = Column(String)
        data = Column(String)

        def __init__(self, user_id, text_pos, button_pos):
            self.id = None
            self.type = None
            self.name = None
            self.data = None

        def __repr__(self):
            return f'<UserBlock({self.id}, {self.type}, {self.name}, {self.data})>'


    class StatusMeta(BASE):

        __tablename__ = 'statusmeta'
        status_id = Column(Integer, primary_key=True)
        whoAprovedUserId = Column(Integer)
        created_dt = Column(DateTime)
        edit_dt = Column(DateTime)

        def __repr__(self):
            return f'<UserContent({self.status_id}, {self.whoAprovedUserId}, {self.created_dt}, {self.edit_dt})>'

    class UserMeta(BASE):
        
        __tablename__ = 'usermeta'
        priv = Column(Integer)
        id = Column(Integer, primary_key=True)
        name = Column(String)

        def __repr__(self):
            return f'<UserMeta({self.priv}, {self.id}, {self.name})>'
    
    class DocumentSignOperation(BASE):

        __tablename__ = 'documentsignoperation'
        id = Column(Integer, primary_key=True)
        type = Column(Integer)
        status_id = Column(Integer)
        whoAprovedUserId = Column(Integer)
        created_dt = Column(DateTime)
        edit_dt = Column(DateTime)
        user_id = Column(Integer)  
        document_id = Column(Integer)

        def __repr__(self):
            return f'<DocumentSignOperation({self.id}, {self.type}, {self.status_id}, {self.whoAprovedUserId}, {self.created_dt}, {self.edit_dt}, {self.user_id}, {self.document_id})>'

    class DocumentSignOperationJ(BASE):

        __tablename__ = 'documentsignoperationj'
        journal_id = Column(Integer, primary_key=True)
        id = Column(Integer)
        type = Column(Integer)
        status_id = Column(Integer)
        whoAprovedUserId = Column(Integer)
        created_dt = Column(DateTime)
        edit_dt = Column(DateTime)
        user_id = Column(Integer)  
        document_id = Column(Integer)

        def __repr__(self):
            return f'<DocumentSignOperationJ({self.journal_id}, {self.id}, {self.type}, {self.status_id}, {self.whoAprovedUserId}, {self.created_dt}, {self.edit_dt}, {self.user_id}, {self.document_id})>'

    class CreditOperation(BASE):

        __tablename__ = 'creditoperation'
        id = Column(Integer, primary_key=True)
        type = Column(Integer)
        status_id = Column(Integer)
        whoAprovedUserId = Column(Integer)
        created_dt = Column(DateTime)
        edit_dt = Column(DateTime)
        acount_id = Column(Integer)
        period = Column(DateTime)
        currency = Column(String)
        amount = Column(BigInteger)

        def __repr__(self):
            return f'<CreditOperation({self.id}, {self.type}, {self.status_id}, {self.whoAprovedUserId}, {self.created_dt}, {self.edit_dt}, {self.acount_id}, {self.period}, {self.currency}, {self.amount})>'



    class CreditOperationJ(BASE):

        __tablename__ = 'creditoperationj'
        journal_id = Column(Integer, primary_key=True)
        id = Column(Integer)
        type = Column(Integer)
        status_id = Column(Integer)
        whoAprovedUserId = Column(Integer)
        created_dt = Column(DateTime)
        edit_dt = Column(DateTime)
        acount_id = Column(Integer)
        period = Column(DateTime)
        currency = Column(String)
        amount = Column(BigInteger)

        def __repr__(self):
            return f'<CreditOperationJ({self.journal_id}, {self.id}, {self.type}, {self.status_id}, {self.whoAprovedUserId}, {self.created_dt}, {self.edit_dt}, {self.acount_id}, {self.period}, {self.currency}, {self.amount})>'


    class Transaction(BASE):

        __tablename__ = 'transaction'
        from_acount_id = Column(Integer)
        to_acount_id = Column(Integer)
        amount = Column(BigInteger)
        id = Column(Integer, primary_key=True)
        type = Column(Integer)
        status_id = Column(Integer)
        whoAprovedUserId = Column(Integer)
        created_dt = Column(DateTime)
        edit_dt = Column(DateTime)

        def __repr__(self):
            return f'<Transaction({self.from_acount_id}, {self.to_acount_id}, {self.amount}, {self.id}, {self.type}, {self.status_id}, {self.whoAprovedUserId}, {self.created_dt}, {self.edit_dt})>'

    class TransactionJ(BASE):

        __tablename__ = 'transactionj'
        from_acount_id = Column(Integer)
        to_acount_id = Column(Integer)
        amount = Column(BigInteger)
        journal_id = Column(Integer, primary_key=True)
        id = Column(Integer)
        type = Column(Integer)
        status_id = Column(Integer)
        whoAprovedUserId = Column(Integer)
        created_dt = Column(DateTime)
        edit_dt = Column(DateTime)

        def __repr__(self):
            return f'<TransactionJ({self.from_acount_id}, {self.to_acount_id}, {self.amount}, {self.journal_id}, {self.id}, {self.type}, {self.status_id}, {self.whoAprovedUserId}, {self.created_dt}, {self.edit_dt})>'


    def __init__(self, path):
        # self.database_engine = create_engine(f'sqlite:///{path}', echo=False, pool_recycle=7200, connect_args={'check_same_thread': False})
        self.database_engine = create_engine('postgresql://' + os.environ.get('bd_log') + ':' + os.environ.get('bd_pass') + '@' + os.environ.get('bd_addr') +":" + os.environ.get('bd_ip')+ '/dbname')
        BASE.metadata.create_all(self.database_engine)

        session = sessionmaker(bind=self.database_engine)
        self.session = session()

        self.session.commit()

x = Storage('test')