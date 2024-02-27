--
-- PostgreSQL database dump
--
create role azure_pg_admin;

-- Dumped from database version 16.0
-- Dumped by pg_dump version 16.2 (Debian 16.2-1.pgdg120+2)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: public; Type: SCHEMA; Schema: -; Owner: azure_pg_admin
--


ALTER SCHEMA public OWNER TO azure_pg_admin;

--
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: azure_pg_admin
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: available_event; Type: TABLE; Schema: public; Owner: ticket_admin
--

CREATE TABLE public.available_event (
    id integer NOT NULL,
    start_time timestamp without time zone,
    name character varying(50)
);


ALTER TABLE public.available_event OWNER TO ticket_admin;

--
-- Name: ticket; Type: TABLE; Schema: public; Owner: ticket_admin
--

CREATE TABLE public.ticket (
    id integer NOT NULL,
    event_id integer,
    scanned boolean,
    identifier character varying(100)
);


ALTER TABLE public.ticket OWNER TO ticket_admin;

--
-- Data for Name: available_event; Type: TABLE DATA; Schema: public; Owner: ticket_admin
--

COPY public.available_event (id, start_time, name) FROM stdin;
1	2024-02-13 17:01:27.342377	Imagine Dragons
2	2024-02-14 17:01:27.342377	Daft Punk
3	2024-02-15 17:01:27.342377	Taylor Swift
4	2024-02-16 17:01:27.342377	Billy Ray Cyrus
5	2024-02-17 17:01:27.342377	Will Smith
\.


--
-- Data for Name: ticket; Type: TABLE DATA; Schema: public; Owner: ticket_admin
--

COPY public.ticket (id, event_id, scanned, identifier) FROM stdin;
1	1	f	1330388921767591717507
2	5	f	130599901382945554836
3	1	f	15494314701859200121229
4	2	f	13505048421580637957799
5	1	f	133216423420699443674
6	1	f	13047272731600839781885
7	5	f	100883546386356004274
8	3	f	543780453273225895119
9	2	f	19746178161158455877461
10	1	f	4449905961517708809532
11	3	f	12152338421603309806220
12	2	f	1937971631259533398326
13	5	f	2800063971955759342746
14	5	f	1713084645318875849941
15	1	f	10849736652101941676744
16	1	f	5323489911733654815992
17	4	f	8312546661913781326418
18	4	f	1091495919516467123261
19	4	f	19237177941181080227504
20	4	f	1521536406765667305701
21	4	f	16547884251834154668307
22	4	f	1558508289338212142819
23	4	f	1160078523168099501984
24	4	f	265445981854681795196
25	4	f	8241515621246183190341
26	4	f	18985088111251069361627
27	4	f	60628467767704902347
28	4	f	10533565311831191101449
29	4	f	774566062820774249430
30	4	f	81626106025620522284
31	4	f	353711035439665570309
32	3	f	364950791370723325251
33	5	f	1435637384544145770724
34	4	f	9075116841206233368603
35	4	f	16420554201057486243371
36	4	f	21317569121147271727620
37	4	f	19237879071292324823640
38	4	f	5003862112117182119617
39	4	f	1063726202470015968189
40	4	f	14359762751380323466225
\.


--
-- Name: available_event available_event_pkey; Type: CONSTRAINT; Schema: public; Owner: ticket_admin
--

ALTER TABLE ONLY public.available_event
    ADD CONSTRAINT available_event_pkey PRIMARY KEY (id);


--
-- Name: ticket ticket_pkey; Type: CONSTRAINT; Schema: public; Owner: ticket_admin
--

ALTER TABLE ONLY public.ticket
    ADD CONSTRAINT ticket_pkey PRIMARY KEY (id);


--
-- Name: ticket ticket_event_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: ticket_admin
--

ALTER TABLE ONLY public.ticket
    ADD CONSTRAINT ticket_event_id_fkey FOREIGN KEY (event_id) REFERENCES public.available_event(id);


--
-- PostgreSQL database dump complete
--

