using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        DO $$
        BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'user_role') THEN
        create type user_role as enum
        (
            'none',
            'admin',
            'customer'
        );
        END IF;
        END$$;

        CREATE TABLE IF NOT EXISTS users
        (
            user_id bigint primary key generated always as identity ,
            user_name text not null ,
            user_role user_role not null ,
            user_password text not null
        );

        CREATE TABLE IF NOT EXISTS cards
        (
            card_id bigint primary key generated always as identity ,
            card_name text not null ,
            owner_card_id bigint not null references users(user_id) ,
            card_password text not null ,
            card_bill integer
        );

        CREATE TABLE IF NOT EXISTS transactions
        (
            card_id bigint not null references cards(card_id) ,
            transaction_name text not null ,
            transaction_date text not null ,
            
            primary key (order_result_id, product_id)
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table users;
        drop table cards
        drop table transactions

        drop type user_role;
        """;
}