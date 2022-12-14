-- CREATE DATABASE fids;

-- CREATE TABLE [dbo].[flight_details] (
--     [flight_id]          INT           IDENTITY (1000, 1) NOT NULL,
--     [flight_no]          NVARCHAR (10) NOT NULL,
--     [airline]            NVARCHAR (50) NOT NULL,
--     [origin]             NVARCHAR (40) NOT NULL,
--     [origin_iata]        NVARCHAR (5)  NOT NULL,
--     [departure_time]     TIME (0)      NOT NULL,
--     [departure_terminal] INT           NOT NULL,
--     [destination]        NVARCHAR (40) NOT NULL,
--     [destination_iata]   NVARCHAR (5)  NOT NULL,
--     [arrival_time]       TIME (0)      NOT NULL,
--     [arrival_terminal]   INT           NOT NULL,
--     [flight_date]        DATE          NOT NULL,
--     [flight_duration]    NVARCHAR (15) NOT NULL,
--     CONSTRAINT [PK_flight_details] PRIMARY KEY CLUSTERED ([flight_id] ASC)
-- );

-- INSERT [dbo].[flight_details] (
--     [flight_no], 
--     [airline], 
--     [origin], 
--     [origin_iata], 
--     [departure_time], 
--     [departure_terminal], 
--     [destination], 
--     [destination_iata], 
--     [arrival_time], 
--     [arrival_terminal], 
--     [flight_date], 
--     [flight_duration]
-- ) VALUES (
--     'KB150',
--     'Druk Air',
--     'Paro',
--     'PBH',
--     '08:30',
--     1,
--     'Bangkok',
--     'BKK',
--     '12:40',
--     5,
--     '2022-09-24',
--     '04hrs 10mins' 
-- )


-- INSERT [dbo].[flight_details] (
--     [flight_no], 
--     [airline], 
--     [origin], 
--     [origin_iata], 
--     [departure_time], 
--     [departure_terminal], 
--     [destination], 
--     [destination_iata], 
--     [arrival_time], 
--     [arrival_terminal], 
--     [flight_date], 
--     [flight_duration]
-- ) VALUES (
--     'B3701',
--     'Bhutan Airlines',
--     'Bangkok',
--     'BKK',
--     '06:30',
--     2,
--     'Kolkata',
--     'CCU',
--     '09:30',
--     4,
--     '2022-09-19',
--     '02hrs 30mins' 
-- )


-- INSERT [dbo].[flight_details] (
--     [flight_no], 
--     [airline], 
--     [origin], 
--     [origin_iata], 
--     [departure_time], 
--     [departure_terminal], 
--     [destination], 
--     [destination_iata], 
--     [arrival_time], 
--     [arrival_terminal], 
--     [flight_date], 
--     [flight_duration]
-- ) VALUES (
--     'B3700',
--     'Bhutan Airlines',
--     'Paro',
--     'PBH',
--     '10:30',
--     1,
--     'Kolkata',
--     'CCU',
--     '11:40',
--     4,
--     '2022-09-23',
--     '01hr 05mins' 
-- )


-- CREATE TABLE [dbo].[auth] (
--     [id]       NVARCHAR (30) NOT NULL,
--     [password] NVARCHAR (30) NOT NULL
-- );

-- INSERT [dbo].[auth] (
--     [id],
--     [password]
-- ) VALUES (
--     'dca@admin.fids.bt',
--     'dca.admin'
-- )

-- INSERT [dbo].[auth] (
--     [id],
--     [password]
-- ) VALUES (
--     'drukair@admin.fids.bt',
--     'drukair.admin'
-- )

-- INSERT [dbo].[auth] (
--     [id],
--     [password]
-- ) VALUES (
--     'bhutanairlines@admin.fids.bt',
--     'bhutanairlines.admin'
-- )