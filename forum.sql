--
-- PostgreSQL database dump
--

-- Dumped from database version 15.4
-- Dumped by pg_dump version 15.4

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Messages; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."Messages" (
    "Id" uuid NOT NULL,
    "CreatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "UpdatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "Body" text NOT NULL,
    "PostId" uuid,
    "UserId" uuid NOT NULL,
    "SearchVector" tsvector GENERATED ALWAYS AS (to_tsvector('english'::regconfig, "Body")) STORED
);


ALTER TABLE public."Messages" OWNER TO quocanh;

--
-- Name: PostTag; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."PostTag" (
    "PostId" uuid NOT NULL,
    "TagsId" uuid NOT NULL
);


ALTER TABLE public."PostTag" OWNER TO quocanh;

--
-- Name: Posts; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."Posts" (
    "Id" uuid NOT NULL,
    "CreatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "UpdatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "Subject" character varying(128) NOT NULL,
    "InitialMessageId" uuid NOT NULL,
    "SearchVector" tsvector GENERATED ALWAYS AS (to_tsvector('english'::regconfig, ("Subject")::text)) STORED,
    "Tag" uuid NOT NULL
);


ALTER TABLE public."Posts" OWNER TO quocanh;

--
-- Name: Tags; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."Tags" (
    "Id" uuid NOT NULL,
    "CreatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "UpdatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "Name" text NOT NULL
);


ALTER TABLE public."Tags" OWNER TO quocanh;

--
-- Name: UserPasswordResetTokens; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."UserPasswordResetTokens" (
    "Token" text NOT NULL,
    "UserId" uuid NOT NULL,
    "ExpirationTime" timestamp with time zone NOT NULL
);


ALTER TABLE public."UserPasswordResetTokens" OWNER TO quocanh;

--
-- Name: UserPermissions; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."UserPermissions" (
    "Permission" character varying(32) NOT NULL,
    "UserId" uuid NOT NULL
);


ALTER TABLE public."UserPermissions" OWNER TO quocanh;

--
-- Name: UserRefreshTokens; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."UserRefreshTokens" (
    "Token" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "CreatedTime" timestamp with time zone NOT NULL,
    "ExpiryTime" timestamp with time zone NOT NULL
);


ALTER TABLE public."UserRefreshTokens" OWNER TO quocanh;

--
-- Name: Users; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "CreatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "UpdatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "Email" character varying(261) NOT NULL,
    "PasswordHash" character varying(61) NOT NULL
);


ALTER TABLE public."Users" OWNER TO quocanh;

--
-- Name: Views; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."Views" (
    "Id" uuid NOT NULL,
    "CreatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "UpdatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "PostId" uuid NOT NULL
);


ALTER TABLE public."Views" OWNER TO quocanh;

--
-- Name: Votes; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."Votes" (
    "UserId" uuid NOT NULL,
    "MessageId" uuid NOT NULL,
    "CreatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "UpdatedTime" timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "Weight" integer NOT NULL
);


ALTER TABLE public."Votes" OWNER TO quocanh;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: quocanh
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO quocanh;

--
-- Data for Name: Messages; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."Messages" ("Id", "CreatedTime", "UpdatedTime", "Body", "PostId", "UserId") FROM stdin;
e75f1a64-e268-44c7-a6f5-7930335a1bf3	2023-12-05 21:49:09.179914+07	2023-12-05 21:49:09.179914+07	<ol><li><p>Firstly click “fx” symbol</p></li><li><p>At Message box write #[vars.employeeId],</p></li><li><p>Click “fx” symbol again</p></li><li><p>click save, otherwise I always see error shown on Logger component (marked with yellow color)</p></li></ol><p><br></p>	9d971c73-c194-44f1-bb9b-b26acc2f700c	57cebff1-15ba-4786-870b-141bf0d08699
bb0302cd-6a5e-43d2-83e3-304073bed9e3	2023-12-05 21:49:45.264197+07	2023-12-05 21:49:45.264197+07	<ul><li><p>kkkk</p></li><li><p>ajsdljsaldjlad</p></li><li><p>aslkdashdkd</p></li></ul><p></p>	9de36b48-0739-4c4a-ad75-b80feb5d8e9d	57cebff1-15ba-4786-870b-141bf0d08699
5dc94f22-35af-4a6b-bb29-d1ce0bdf9b6c	2023-12-06 00:55:32.004252+07	2023-12-06 00:55:32.004252+07	<blockquote><p>We are running an MVC 5 4.8 app on Azure. I setup a HttpHandler to add a header to static files. It works without issue on our app service that does not have Front Door, but on the one that does, it seems the Content-Type header is getting lost on some of the files inconsistently. The only thing consistent is if the HttpHandler is hit, the problem arises (I can set IsUsingAccessControlAllowOrigin to false and it still occurs).</p><p>Static files are not getting loaded due to this error:</p></blockquote>	75bbad27-efcc-42d0-a02c-72843704a8e2	5cd807db-5e58-4af0-9f2a-12753986e826
c20f297f-5e9f-4742-9d11-3481f0b0a338	2023-12-06 01:00:34.173317+07	2023-12-06 01:00:34.173317+07	<p><br>I have a 64-bit unsigned int flag variable called <code>uintflag</code> that can only hold the values <code>0</code> or <code>1</code>.</p><p>I need to convert <code>0</code> to <code>1.0</code> and <code>1</code> to <code>-1.0</code>. This conversion is from an unsigned integer (64-bit) to a double (64-bit).</p><p>While the benchmarking is judged on an x86-64 platform, I'm writing GNU, and I don't know in what processor it may be run, so a goal is to write portable code that can run on various architectures. Therefore, to ensure correctness on different platforms, I cannot rely on x86-specific bit formats. I prioritize correctness over performance optimization for non-x86 platforms.</p><p>In x86, the conversion of uint to double consumes 5 cycles, so this is expensive</p>	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8	5cd807db-5e58-4af0-9f2a-12753986e826
b68ff2d8-b25d-4555-913e-eff1f29fea4b	2023-12-06 01:01:15.692096+07	2023-12-06 01:01:15.692096+07	<p></p><p><strong>How can it be that even having everything well configured on the side of the google console:</strong></p><p><strong>-Billing account -API KEYs activated and associated with the billing account -APIs loaded in my FlutterFlow project</strong></p><p><strong>Do I still have this during the construction of my app?</strong></p><p><strong>thanks for your help</strong></p>	e4634520-89f1-4412-9a4d-18a9f205a9e4	5cd807db-5e58-4af0-9f2a-12753986e826
9733dfc4-46cf-46e6-bf72-78cbff15f8ea	2023-12-06 01:01:46.657394+07	2023-12-06 01:01:46.657394+07	<p>So I'm really interested what the reasoning behind the HeaderMap implementation is (I <em>have</em> read the source comments ... I really don't think they reflect reality - I don't see how "the special nature of HTTP headers" warrants that implementation - even with single value headers, HashMap is significantly faster).</p><p>Incidentally, this comes up as I'm trying to implement "retain" on HeaderMap - which looks like a HECK of a lot of code in its current form.</p><p><br></p>	4f26f9e3-1362-435f-b0e9-f7632859e3f3	5cd807db-5e58-4af0-9f2a-12753986e826
0cccefaa-feea-46d6-ba58-990342017996	2023-12-07 17:34:56.753419+07	2023-12-07 17:34:56.753419+07	kkk hay qua	4f26f9e3-1362-435f-b0e9-f7632859e3f3	d29dca40-986a-4902-a0e9-46c2b1766010
6f79fead-ee85-4fb9-9160-088c9db28aaf	2023-12-07 17:35:10.49584+07	2023-12-07 17:35:10.49584+07	nice xu`	e4634520-89f1-4412-9a4d-18a9f205a9e4	d29dca40-986a-4902-a0e9-46c2b1766010
f488c754-eb91-4064-a767-b5d04849753c	2023-12-07 17:35:24.702692+07	2023-12-07 17:35:24.702692+07	good job man	75bbad27-efcc-42d0-a02c-72843704a8e2	d29dca40-986a-4902-a0e9-46c2b1766010
ef4f2a1e-9762-4dd2-b907-9e1132725e16	2023-12-07 17:37:37.930931+07	2023-12-07 17:37:37.930931+07	now someone who can answer? Share a link to this question via email, Twitter, or Facebook.	75bbad27-efcc-42d0-a02c-72843704a8e2	4080b3e9-84b3-4425-832d-8bcdbffaf273
13c86b6e-a761-44eb-88f6-5adcec890b09	2023-12-07 17:38:13.504136+07	2023-12-07 17:38:13.504136+07	hay v sao ong oi 	75bbad27-efcc-42d0-a02c-72843704a8e2	5cd807db-5e58-4af0-9f2a-12753986e826
8fcdeb48-234f-4d5d-a95f-49d9c7bfe8f5	2023-12-07 17:39:03.099068+07	2023-12-07 17:39:03.099068+07	<p>I would like to gather information every minute, and if it's not empty, then consume the information in a different process. My code right now looks like:</p>	405817da-44e1-4e6c-8805-93168575966a	5cd807db-5e58-4af0-9f2a-12753986e826
dac72833-07a7-43de-910c-a92ef578a3ce	2023-12-07 17:39:11.948664+07	2023-12-07 17:39:11.948664+07	help me python	405817da-44e1-4e6c-8805-93168575966a	5cd807db-5e58-4af0-9f2a-12753986e826
46ccc521-20c3-4e11-9843-fac45dc091ef	2023-12-07 17:39:53.992057+07	2023-12-07 17:39:53.992057+07	u can log it and screen it for me an	405817da-44e1-4e6c-8805-93168575966a	4080b3e9-84b3-4425-832d-8bcdbffaf273
2d200335-eccb-48e3-b9e7-c853c2c08ae4	2023-12-07 17:40:38.606806+07	2023-12-07 17:40:38.606806+07	so about it u just replace type string to int  my man	405817da-44e1-4e6c-8805-93168575966a	d29dca40-986a-4902-a0e9-46c2b1766010
d1d054d0-ac1e-49df-a387-72e03a1ca687	2023-12-07 17:41:22.240271+07	2023-12-07 17:41:22.240271+07	nice xu` man oi	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8	57cebff1-15ba-4786-870b-141bf0d08699
efa666f6-70b9-46d9-9e9f-096b4097372e	2023-12-07 17:43:18.881606+07	2023-12-07 17:43:18.881606+07	<p>I am well are aware that not all phones yield camera intrinsics via the <code>camera2</code> API. However, I find it very puzzling that some phones yield intrinsics while other <strong>almost identical</strong> phones do not. E.g. the Samsung Galaxy S20 FE (SM-G780G) yields intrinsics via the <code>camera2</code> API, whereas the Samsung Galaxy S20 5G (SM-G981B) strangely does not.</p>	e5ddb792-59bb-45d5-97d4-f28a5f4abe31	4080b3e9-84b3-4425-832d-8bcdbffaf273
\.


--
-- Data for Name: PostTag; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."PostTag" ("PostId", "TagsId") FROM stdin;
9d971c73-c194-44f1-bb9b-b26acc2f700c	0edbf28d-cd5f-4e16-bba7-2619af2e532a
9de36b48-0739-4c4a-ad75-b80feb5d8e9d	92289034-4661-4eba-ba26-e694930d6977
75bbad27-efcc-42d0-a02c-72843704a8e2	a3588888-7a98-4d45-b394-ea9bf4fd7038
95fb29ce-c7fa-42c5-9c70-1d94f15a81c8	a3588888-7a98-4d45-b394-ea9bf4fd7038
95fb29ce-c7fa-42c5-9c70-1d94f15a81c8	a95ea924-5137-48ff-9dd0-8e0cffb27192
e4634520-89f1-4412-9a4d-18a9f205a9e4	4455d3b2-9f9d-4361-8e0a-13bfd18c61d8
4f26f9e3-1362-435f-b0e9-f7632859e3f3	1e24528e-dd2a-48a7-b302-5b502dad7392
405817da-44e1-4e6c-8805-93168575966a	4ed06c0e-f8fa-41ea-a782-22bca42a998a
405817da-44e1-4e6c-8805-93168575966a	92289034-4661-4eba-ba26-e694930d6977
e5ddb792-59bb-45d5-97d4-f28a5f4abe31	48e5674c-8b90-49d4-9e1d-9167366a6e16
e5ddb792-59bb-45d5-97d4-f28a5f4abe31	97f10c8b-888a-4213-951b-8a55c1215a60
\.


--
-- Data for Name: Posts; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."Posts" ("Id", "CreatedTime", "UpdatedTime", "Subject", "InitialMessageId", "Tag") FROM stdin;
9d971c73-c194-44f1-bb9b-b26acc2f700c	2023-12-05 21:49:09.259522+07	2023-12-05 21:49:09.259522+07	Print out variables in Logger component in MuleSoft Anypoint Studio	e75f1a64-e268-44c7-a6f5-7930335a1bf3	00000000-0000-0000-0000-000000000000
9de36b48-0739-4c4a-ad75-b80feb5d8e9d	2023-12-05 21:49:45.275717+07	2023-12-05 21:49:45.275717+07	Game object lies down when I put NavmeshAgent as component in avocado-bone	bb0302cd-6a5e-43d2-83e3-304073bed9e3	00000000-0000-0000-0000-000000000000
75bbad27-efcc-42d0-a02c-72843704a8e2	2023-12-06 00:55:32.155003+07	2023-12-06 00:55:32.155003+07	Why is Azure Front Door breaking content-type headers that are set in a HttpHandler?	5dc94f22-35af-4a6b-bb29-d1ce0bdf9b6c	00000000-0000-0000-0000-000000000000
95fb29ce-c7fa-42c5-9c70-1d94f15a81c8	2023-12-06 01:00:34.336725+07	2023-12-06 01:00:34.336725+07	What is the fastest way to map unsigned integer {0,1} to float 64 {1.0,-1.0}?	c20f297f-5e9f-4742-9d11-3481f0b0a338	00000000-0000-0000-0000-000000000000
e4634520-89f1-4412-9a4d-18a9f205a9e4	2023-12-06 01:01:15.701052+07	2023-12-06 01:01:15.701052+07	Google Maps API (FlutterFlow): need help fixing "this page can't load Google Maps correctly"	b68ff2d8-b25d-4555-913e-eff1f29fea4b	00000000-0000-0000-0000-000000000000
4f26f9e3-1362-435f-b0e9-f7632859e3f3	2023-12-06 01:01:46.66438+07	2023-12-06 01:01:46.66438+07	Rust, http::HeaderMap ... why isn't it simply HashMap<HeaderName, Vec<HeaderValue>>?	9733dfc4-46cf-46e6-bf72-78cbff15f8ea	00000000-0000-0000-0000-000000000000
405817da-44e1-4e6c-8805-93168575966a	2023-12-07 17:39:03.157459+07	2023-12-07 17:39:03.157459+07	how to create side tasks in main async loop in Python	8fcdeb48-234f-4d5d-a95f-49d9c7bfe8f5	00000000-0000-0000-0000-000000000000
e5ddb792-59bb-45d5-97d4-f28a5f4abe31	2023-12-07 17:43:18.897868+07	2023-12-07 17:43:18.897868+07	Difference in the Availability of Camera Intrinsics via the Camera2 API Between Almost Identical Phones	efa666f6-70b9-46d9-9e9f-096b4097372e	00000000-0000-0000-0000-000000000000
\.


--
-- Data for Name: Tags; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."Tags" ("Id", "CreatedTime", "UpdatedTime", "Name") FROM stdin;
b72f3dd0-cbc9-4009-8138-005d1a4c3787	2023-12-05 13:07:58.610977+07	2023-12-05 13:07:58.610977+07	ajjsnd
0edbf28d-cd5f-4e16-bba7-2619af2e532a	2023-12-05 21:49:09.0568+07	2023-12-05 21:49:09.0568+07	js
92289034-4661-4eba-ba26-e694930d6977	2023-12-05 21:49:45.251547+07	2023-12-05 21:49:45.251547+07	python
a3588888-7a98-4d45-b394-ea9bf4fd7038	2023-12-06 00:55:31.879199+07	2023-12-06 00:55:31.879199+07	javascript
a95ea924-5137-48ff-9dd0-8e0cffb27192	2023-12-06 01:00:34.00634+07	2023-12-06 01:00:34.00634+07	typescript
4455d3b2-9f9d-4361-8e0a-13bfd18c61d8	2023-12-06 01:01:15.683511+07	2023-12-06 01:01:15.683511+07	eng
1e24528e-dd2a-48a7-b302-5b502dad7392	2023-12-06 01:01:46.647017+07	2023-12-06 01:01:46.647017+07	c++
4ed06c0e-f8fa-41ea-a782-22bca42a998a	2023-12-07 17:39:03.07923+07	2023-12-07 17:39:03.07923+07	question
48e5674c-8b90-49d4-9e1d-9167366a6e16	2023-12-07 17:43:18.875481+07	2023-12-07 17:43:18.875481+07	android
97f10c8b-888a-4213-951b-8a55c1215a60	2023-12-07 17:43:18.875481+07	2023-12-07 17:43:18.875481+07	google-play
\.


--
-- Data for Name: UserPasswordResetTokens; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."UserPasswordResetTokens" ("Token", "UserId", "ExpirationTime") FROM stdin;
\.


--
-- Data for Name: UserPermissions; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."UserPermissions" ("Permission", "UserId") FROM stdin;
create_user	57cebff1-15ba-4786-870b-141bf0d08699
\.


--
-- Data for Name: UserRefreshTokens; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."UserRefreshTokens" ("Token", "UserId", "CreatedTime", "ExpiryTime") FROM stdin;
f25f1a92-52aa-4ee7-9720-6d83696d9d37	57cebff1-15ba-4786-870b-141bf0d08699	1970-01-01 08:00:00+08	2024-01-04 13:07:45.472728+07
8e493f0b-4621-4b83-b890-85778592918a	57cebff1-15ba-4786-870b-141bf0d08699	1970-01-01 08:00:00+08	2024-01-04 16:18:07.05949+07
e31400b5-00a4-4b46-8324-3c8beca44492	57cebff1-15ba-4786-870b-141bf0d08699	1970-01-01 08:00:00+08	2024-01-04 21:47:03.844702+07
856b21fd-b179-44ed-8443-36e822b697d4	57cebff1-15ba-4786-870b-141bf0d08699	1970-01-01 08:00:00+08	2024-01-05 00:54:11.068964+07
196071b3-85dc-480a-b23a-7deabfec0a08	5cd807db-5e58-4af0-9f2a-12753986e826	1970-01-01 08:00:00+08	2024-01-05 00:54:55.364215+07
d3d430f1-a9b2-4769-8f65-4f47f2c1ed51	5cd807db-5e58-4af0-9f2a-12753986e826	1970-01-01 08:00:00+08	2024-01-05 02:02:50.19893+07
26680df5-f573-4104-975b-94c3372a40c3	5cd807db-5e58-4af0-9f2a-12753986e826	1970-01-01 08:00:00+08	2024-01-05 22:16:32.15189+07
8f38f308-0e33-4cd7-b3f8-2af34c5880b8	d29dca40-986a-4902-a0e9-46c2b1766010	1970-01-01 08:00:00+08	2024-01-06 17:34:50.431566+07
5902c627-23ad-4fdc-96dc-af8f79b26511	4080b3e9-84b3-4425-832d-8bcdbffaf273	1970-01-01 08:00:00+08	2024-01-06 17:35:50.90122+07
793d8946-a687-4646-9bb7-4ed3c2f08471	5cd807db-5e58-4af0-9f2a-12753986e826	1970-01-01 08:00:00+08	2024-01-06 17:38:01.483962+07
54907d7a-a745-4f99-9f49-5dac8c4e1937	4080b3e9-84b3-4425-832d-8bcdbffaf273	1970-01-01 08:00:00+08	2024-01-06 17:39:33.864554+07
0b22193c-08c8-4b16-9806-62eb938e5c5c	d29dca40-986a-4902-a0e9-46c2b1766010	1970-01-01 08:00:00+08	2024-01-06 17:40:09.018204+07
59a83997-fffc-48ce-8346-280dbe0994d4	57cebff1-15ba-4786-870b-141bf0d08699	1970-01-01 08:00:00+08	2024-01-06 17:41:14.131537+07
5935673f-d1b3-428d-8bc7-fae5c6844b41	4080b3e9-84b3-4425-832d-8bcdbffaf273	1970-01-01 08:00:00+08	2024-01-06 17:42:34.521401+07
\.


--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."Users" ("Id", "CreatedTime", "UpdatedTime", "Email", "PasswordHash") FROM stdin;
57cebff1-15ba-4786-870b-141bf0d08699	2023-12-05 13:05:03.803755+07	2023-12-05 13:05:03.803755+07	admin@gmail.com	$2a$11$MC255/LaCFI./uqSdaa8xO7u.HOwDHJvVxT526mKYvqP5Xv63SBIq
5cd807db-5e58-4af0-9f2a-12753986e826	2023-12-06 00:54:52.702773+07	2023-12-06 00:54:52.702773+07	quocanh@gmail.com	$2a$11$SfxxbOKkK6bvHMjS4oz9zujytBSBOWqIOKDMElg7nyZNX33mieS76
d29dca40-986a-4902-a0e9-46c2b1766010	2023-12-07 17:34:46.289235+07	2023-12-07 17:34:46.289235+07	quocduy@gmail.com	$2a$11$zw73XuYeUI3RDUfvk2NCf.AvSQ4xYWNFnunBkBcxRBBo7/XR1h8LW
4080b3e9-84b3-4425-832d-8bcdbffaf273	2023-12-07 17:35:45.719851+07	2023-12-07 17:35:45.719851+07	anhla12h@gmail.com	$2a$11$qDi7iBqLyIuzBI2p7zHlvOU9k6LvvcKHKnXR/Mwhx8/VVCxXyPORK
\.


--
-- Data for Name: Views; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."Views" ("Id", "CreatedTime", "UpdatedTime", "PostId") FROM stdin;
94d32210-9d0b-4ff4-8444-496c8a33890d	2023-12-05 21:49:47.806199+07	2023-12-05 21:49:47.806199+07	9de36b48-0739-4c4a-ad75-b80feb5d8e9d
4fc81d48-96db-4945-aa84-27a279c95c5e	2023-12-05 21:50:07.870961+07	2023-12-05 21:50:07.870961+07	9d971c73-c194-44f1-bb9b-b26acc2f700c
d8b93d0a-d8e9-43f6-b3ee-607fbac37b63	2023-12-05 21:50:07.956104+07	2023-12-05 21:50:07.956104+07	9d971c73-c194-44f1-bb9b-b26acc2f700c
2cb17d9c-5a1c-4006-bf0d-656e4c3a6cb5	2023-12-06 01:01:55.099638+07	2023-12-06 01:01:55.099638+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
ecabd6df-c0da-41d0-9d7d-e8047a08679c	2023-12-06 01:01:56.726328+07	2023-12-06 01:01:56.726328+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
8ac7dac6-3d64-46cc-a5ef-a2b5e63b7553	2023-12-06 01:02:02.063358+07	2023-12-06 01:02:02.063358+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
21007bf6-9fa0-40f4-9f97-a0d0ad39eca0	2023-12-06 01:02:04.523064+07	2023-12-06 01:02:04.523064+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
a27c7997-772f-456e-b7dd-e1c7e8f9f097	2023-12-06 01:02:07.200124+07	2023-12-06 01:02:07.200124+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
c3786502-2afb-44e2-ae6e-2453253c8a18	2023-12-06 01:02:08.588307+07	2023-12-06 01:02:08.588307+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
f2faec7a-0a36-4116-8305-132a4fbc8fcc	2023-12-06 01:02:35.163425+07	2023-12-06 01:02:35.163425+07	e4634520-89f1-4412-9a4d-18a9f205a9e4
f1d31055-5ef9-4030-9783-6d6c789b9e6d	2023-12-06 01:02:36.565555+07	2023-12-06 01:02:36.565555+07	e4634520-89f1-4412-9a4d-18a9f205a9e4
373a2fd8-7228-4920-b699-1a1986038561	2023-12-06 01:02:39.753965+07	2023-12-06 01:02:39.753965+07	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8
50a58e44-42e6-4f29-b164-22624a40d859	2023-12-06 01:02:41.903969+07	2023-12-06 01:02:41.903969+07	75bbad27-efcc-42d0-a02c-72843704a8e2
f9d44cdb-246d-4af1-9535-6f946457b1ff	2023-12-06 02:02:45.862116+07	2023-12-06 02:02:45.862116+07	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8
687345d0-9b47-46ff-9f6d-a92fa870aac5	2023-12-06 22:02:45.953036+07	2023-12-06 22:02:45.953036+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
3fcf6e33-a570-45f0-b020-4d81add9eb1e	2023-12-06 22:14:57.82512+07	2023-12-06 22:14:57.82512+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
675ee733-f259-443c-9205-0e394f78a463	2023-12-06 22:20:28.471213+07	2023-12-06 22:20:28.471213+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
b531e9b0-3a50-406d-b592-bbc363735239	2023-12-06 22:27:24.02641+07	2023-12-06 22:27:24.02641+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
6a29b970-888e-42b2-8e42-aadf5ba10bbd	2023-12-06 23:38:17.514689+07	2023-12-06 23:38:17.514689+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
472718f2-9f57-4a16-bba8-dede34d9fcbd	2023-12-06 23:38:48.032025+07	2023-12-06 23:38:48.032025+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
2659e046-204f-4628-bfc6-caae91aabb4e	2023-12-06 23:39:07.102508+07	2023-12-06 23:39:07.102508+07	e4634520-89f1-4412-9a4d-18a9f205a9e4
def197be-7d73-4020-bd5f-cd2120fd85e4	2023-12-07 17:34:53.394284+07	2023-12-07 17:34:53.394284+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
2fc04f87-be3b-4935-a6be-36058a4c14de	2023-12-07 17:34:56.815895+07	2023-12-07 17:34:56.815895+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
dc053926-730a-4b22-8247-97e611784151	2023-12-07 17:34:59.94633+07	2023-12-07 17:34:59.94633+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
993c3567-4db2-45cc-ba76-167a9a8d3e45	2023-12-07 17:35:05.170787+07	2023-12-07 17:35:05.170787+07	e4634520-89f1-4412-9a4d-18a9f205a9e4
baf6e45e-68eb-4614-9969-cec5c771bd26	2023-12-07 17:35:06.970358+07	2023-12-07 17:35:06.970358+07	e4634520-89f1-4412-9a4d-18a9f205a9e4
8d2e22ce-c00f-4ca1-b589-f51fe676d61b	2023-12-07 17:35:10.524817+07	2023-12-07 17:35:10.524817+07	e4634520-89f1-4412-9a4d-18a9f205a9e4
fa845b68-e811-4010-a85a-5584f0dc3db1	2023-12-07 17:35:17.332101+07	2023-12-07 17:35:17.332101+07	75bbad27-efcc-42d0-a02c-72843704a8e2
7407d21e-d52b-4471-b177-9faf111739f0	2023-12-07 17:35:24.735925+07	2023-12-07 17:35:24.735925+07	75bbad27-efcc-42d0-a02c-72843704a8e2
0b479308-143c-4857-9ce4-e79c54a3f67f	2023-12-07 17:35:27.257095+07	2023-12-07 17:35:27.257095+07	75bbad27-efcc-42d0-a02c-72843704a8e2
b02ed192-7041-4da4-abd6-8c2dcb948c91	2023-12-07 17:35:54.820684+07	2023-12-07 17:35:54.820684+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
1c607911-614c-49fe-b855-d532eae927cf	2023-12-07 17:35:54.900844+07	2023-12-07 17:35:54.900844+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
a9418164-9ff5-4620-9ec9-af0b1d8d8f41	2023-12-07 17:35:56.080054+07	2023-12-07 17:35:56.080054+07	4f26f9e3-1362-435f-b0e9-f7632859e3f3
31a2c22a-0f96-4b68-82c4-a32176f07f98	2023-12-07 17:37:13.627634+07	2023-12-07 17:37:13.627634+07	e4634520-89f1-4412-9a4d-18a9f205a9e4
8c6bc398-5d1c-42ce-822f-0ac556e98402	2023-12-07 17:37:15.585555+07	2023-12-07 17:37:15.585555+07	e4634520-89f1-4412-9a4d-18a9f205a9e4
905950e0-59ea-47cd-8be3-4a3400f49c3c	2023-12-07 17:37:19.961693+07	2023-12-07 17:37:19.961693+07	75bbad27-efcc-42d0-a02c-72843704a8e2
01ac32aa-b1bc-470e-a650-048a37998688	2023-12-07 17:37:23.442165+07	2023-12-07 17:37:23.442165+07	75bbad27-efcc-42d0-a02c-72843704a8e2
004441a8-3f9e-4588-bf4e-b926332fc73a	2023-12-07 17:37:37.973694+07	2023-12-07 17:37:37.973694+07	75bbad27-efcc-42d0-a02c-72843704a8e2
356106e4-7ec3-476d-b535-5b105c10b33f	2023-12-07 17:38:03.291892+07	2023-12-07 17:38:03.291892+07	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8
04e9ee76-25d4-4eb9-93a0-2331b95f449a	2023-12-07 17:38:04.798139+07	2023-12-07 17:38:04.798139+07	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8
a2a0d98f-7052-4b5f-8ea1-933674cab2f6	2023-12-07 17:38:08.563709+07	2023-12-07 17:38:08.563709+07	75bbad27-efcc-42d0-a02c-72843704a8e2
7400d4a5-82c0-4060-8c4d-cf85566e61eb	2023-12-07 17:38:09.730486+07	2023-12-07 17:38:09.730486+07	75bbad27-efcc-42d0-a02c-72843704a8e2
b86c902d-91aa-4c12-94ce-72c17dc4c02c	2023-12-07 17:38:13.528599+07	2023-12-07 17:38:13.528599+07	75bbad27-efcc-42d0-a02c-72843704a8e2
3fed57c1-89ff-48e0-abee-72924d1f3afd	2023-12-07 17:39:05.34704+07	2023-12-07 17:39:05.34704+07	405817da-44e1-4e6c-8805-93168575966a
44e7a1d8-571f-4df2-9e71-57c74011ee75	2023-12-07 17:39:06.707969+07	2023-12-07 17:39:06.707969+07	405817da-44e1-4e6c-8805-93168575966a
971e0a12-af02-418e-9152-adbbbbb3892f	2023-12-07 17:39:11.967006+07	2023-12-07 17:39:11.967006+07	405817da-44e1-4e6c-8805-93168575966a
fa383f91-0fb4-4b92-93eb-76497b68279d	2023-12-07 17:39:35.299818+07	2023-12-07 17:39:35.299818+07	405817da-44e1-4e6c-8805-93168575966a
f4823a8b-6038-4283-8332-1c7eab9df2fb	2023-12-07 17:39:54.014779+07	2023-12-07 17:39:54.014779+07	405817da-44e1-4e6c-8805-93168575966a
b3457416-481c-42a1-875b-c93b328a9292	2023-12-07 17:39:57.607536+07	2023-12-07 17:39:57.607536+07	405817da-44e1-4e6c-8805-93168575966a
0b304ae6-78c8-42aa-a6d8-a7fd94612abb	2023-12-07 17:40:10.178757+07	2023-12-07 17:40:10.178757+07	405817da-44e1-4e6c-8805-93168575966a
3d0edd22-102c-484e-ba5b-c1e3adf46a5e	2023-12-07 17:40:38.626645+07	2023-12-07 17:40:38.626645+07	405817da-44e1-4e6c-8805-93168575966a
7436b38b-518c-4a92-838b-37c6f2dd7a62	2023-12-07 17:40:40.598195+07	2023-12-07 17:40:40.598195+07	405817da-44e1-4e6c-8805-93168575966a
18a18a1b-bfb1-4d10-8937-79ed88edf785	2023-12-07 17:40:48.59523+07	2023-12-07 17:40:48.59523+07	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8
025028d5-4668-4042-8734-b331a3e6b140	2023-12-07 17:40:50.635718+07	2023-12-07 17:40:50.635718+07	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8
63130020-3433-4ff3-91cd-038a9c793024	2023-12-07 17:41:15.790418+07	2023-12-07 17:41:15.790418+07	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8
9e4e859c-6cc7-49aa-adc0-9e2cec7def60	2023-12-07 17:41:17.199231+07	2023-12-07 17:41:17.199231+07	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8
2ef578c2-7e0c-4697-9fb4-2852c1e36d92	2023-12-07 17:41:22.265284+07	2023-12-07 17:41:22.265284+07	95fb29ce-c7fa-42c5-9c70-1d94f15a81c8
\.


--
-- Data for Name: Votes; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."Votes" ("UserId", "MessageId", "CreatedTime", "UpdatedTime", "Weight") FROM stdin;
5cd807db-5e58-4af0-9f2a-12753986e826	9733dfc4-46cf-46e6-bf72-78cbff15f8ea	2023-12-06 01:01:56.697763+07	2023-12-06 01:01:56.697763+07	-1
5cd807db-5e58-4af0-9f2a-12753986e826	b68ff2d8-b25d-4555-913e-eff1f29fea4b	2023-12-06 01:02:36.53216+07	2023-12-06 01:02:36.53216+07	1
d29dca40-986a-4902-a0e9-46c2b1766010	9733dfc4-46cf-46e6-bf72-78cbff15f8ea	2023-12-07 17:34:59.860991+07	2023-12-07 17:34:59.860991+07	-1
d29dca40-986a-4902-a0e9-46c2b1766010	b68ff2d8-b25d-4555-913e-eff1f29fea4b	2023-12-07 17:35:06.922912+07	2023-12-07 17:35:06.922912+07	1
d29dca40-986a-4902-a0e9-46c2b1766010	5dc94f22-35af-4a6b-bb29-d1ce0bdf9b6c	2023-12-07 17:35:27.235161+07	2023-12-07 17:35:27.235161+07	1
4080b3e9-84b3-4425-832d-8bcdbffaf273	9733dfc4-46cf-46e6-bf72-78cbff15f8ea	2023-12-07 17:35:56.047775+07	2023-12-07 17:35:56.047775+07	1
4080b3e9-84b3-4425-832d-8bcdbffaf273	b68ff2d8-b25d-4555-913e-eff1f29fea4b	2023-12-07 17:37:15.551248+07	2023-12-07 17:37:15.551248+07	1
4080b3e9-84b3-4425-832d-8bcdbffaf273	5dc94f22-35af-4a6b-bb29-d1ce0bdf9b6c	2023-12-07 17:37:23.418937+07	2023-12-07 17:37:23.418937+07	1
5cd807db-5e58-4af0-9f2a-12753986e826	c20f297f-5e9f-4742-9d11-3481f0b0a338	2023-12-07 17:38:04.76129+07	2023-12-07 17:38:04.76129+07	1
5cd807db-5e58-4af0-9f2a-12753986e826	5dc94f22-35af-4a6b-bb29-d1ce0bdf9b6c	2023-12-07 17:38:09.695901+07	2023-12-07 17:38:09.695901+07	1
5cd807db-5e58-4af0-9f2a-12753986e826	8fcdeb48-234f-4d5d-a95f-49d9c7bfe8f5	2023-12-07 17:39:06.679255+07	2023-12-07 17:39:06.679255+07	1
4080b3e9-84b3-4425-832d-8bcdbffaf273	8fcdeb48-234f-4d5d-a95f-49d9c7bfe8f5	2023-12-07 17:39:57.574761+07	2023-12-07 17:39:57.574761+07	1
d29dca40-986a-4902-a0e9-46c2b1766010	8fcdeb48-234f-4d5d-a95f-49d9c7bfe8f5	2023-12-07 17:40:40.570983+07	2023-12-07 17:40:40.570983+07	1
d29dca40-986a-4902-a0e9-46c2b1766010	c20f297f-5e9f-4742-9d11-3481f0b0a338	2023-12-07 17:40:50.61573+07	2023-12-07 17:40:50.61573+07	1
57cebff1-15ba-4786-870b-141bf0d08699	c20f297f-5e9f-4742-9d11-3481f0b0a338	2023-12-07 17:41:17.172393+07	2023-12-07 17:41:17.172393+07	1
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: quocanh
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20231205060455_InitialCreate	7.0.11
\.


--
-- Name: Messages PK_Messages; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Messages"
    ADD CONSTRAINT "PK_Messages" PRIMARY KEY ("Id");


--
-- Name: PostTag PK_PostTag; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."PostTag"
    ADD CONSTRAINT "PK_PostTag" PRIMARY KEY ("PostId", "TagsId");


--
-- Name: Posts PK_Posts; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Posts"
    ADD CONSTRAINT "PK_Posts" PRIMARY KEY ("Id");


--
-- Name: Tags PK_Tags; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Tags"
    ADD CONSTRAINT "PK_Tags" PRIMARY KEY ("Id");


--
-- Name: UserPasswordResetTokens PK_UserPasswordResetTokens; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."UserPasswordResetTokens"
    ADD CONSTRAINT "PK_UserPasswordResetTokens" PRIMARY KEY ("Token");


--
-- Name: UserPermissions PK_UserPermissions; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."UserPermissions"
    ADD CONSTRAINT "PK_UserPermissions" PRIMARY KEY ("UserId", "Permission");


--
-- Name: UserRefreshTokens PK_UserRefreshTokens; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."UserRefreshTokens"
    ADD CONSTRAINT "PK_UserRefreshTokens" PRIMARY KEY ("UserId", "Token");


--
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");


--
-- Name: Views PK_Views; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Views"
    ADD CONSTRAINT "PK_Views" PRIMARY KEY ("Id");


--
-- Name: Votes PK_Votes; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Votes"
    ADD CONSTRAINT "PK_Votes" PRIMARY KEY ("UserId", "MessageId");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_Messages_PostId; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE INDEX "IX_Messages_PostId" ON public."Messages" USING btree ("PostId");


--
-- Name: IX_Messages_SearchVector; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE INDEX "IX_Messages_SearchVector" ON public."Messages" USING gin ("SearchVector");


--
-- Name: IX_Messages_UserId; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE INDEX "IX_Messages_UserId" ON public."Messages" USING btree ("UserId");


--
-- Name: IX_PostTag_TagsId; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE INDEX "IX_PostTag_TagsId" ON public."PostTag" USING btree ("TagsId");


--
-- Name: IX_Posts_InitialMessageId; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE UNIQUE INDEX "IX_Posts_InitialMessageId" ON public."Posts" USING btree ("InitialMessageId");


--
-- Name: IX_Posts_SearchVector; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE INDEX "IX_Posts_SearchVector" ON public."Posts" USING gin ("SearchVector");


--
-- Name: IX_UserPasswordResetTokens_UserId; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE UNIQUE INDEX "IX_UserPasswordResetTokens_UserId" ON public."UserPasswordResetTokens" USING btree ("UserId");


--
-- Name: IX_Users_Email; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE UNIQUE INDEX "IX_Users_Email" ON public."Users" USING btree ("Email");


--
-- Name: IX_Views_PostId; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE INDEX "IX_Views_PostId" ON public."Views" USING btree ("PostId");


--
-- Name: IX_Votes_MessageId; Type: INDEX; Schema: public; Owner: quocanh
--

CREATE INDEX "IX_Votes_MessageId" ON public."Votes" USING btree ("MessageId");


--
-- Name: Messages FK_Messages_Posts_PostId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Messages"
    ADD CONSTRAINT "FK_Messages_Posts_PostId" FOREIGN KEY ("PostId") REFERENCES public."Posts"("Id") ON DELETE CASCADE;


--
-- Name: Messages FK_Messages_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Messages"
    ADD CONSTRAINT "FK_Messages_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: PostTag FK_PostTag_Posts_PostId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."PostTag"
    ADD CONSTRAINT "FK_PostTag_Posts_PostId" FOREIGN KEY ("PostId") REFERENCES public."Posts"("Id") ON DELETE CASCADE;


--
-- Name: PostTag FK_PostTag_Tags_TagsId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."PostTag"
    ADD CONSTRAINT "FK_PostTag_Tags_TagsId" FOREIGN KEY ("TagsId") REFERENCES public."Tags"("Id") ON DELETE CASCADE;


--
-- Name: Posts FK_Posts_Messages_InitialMessageId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Posts"
    ADD CONSTRAINT "FK_Posts_Messages_InitialMessageId" FOREIGN KEY ("InitialMessageId") REFERENCES public."Messages"("Id") ON DELETE CASCADE;


--
-- Name: UserPasswordResetTokens FK_UserPasswordResetTokens_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."UserPasswordResetTokens"
    ADD CONSTRAINT "FK_UserPasswordResetTokens_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: UserPermissions FK_UserPermissions_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."UserPermissions"
    ADD CONSTRAINT "FK_UserPermissions_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: UserRefreshTokens FK_UserRefreshTokens_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."UserRefreshTokens"
    ADD CONSTRAINT "FK_UserRefreshTokens_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: Views FK_Views_Posts_PostId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Views"
    ADD CONSTRAINT "FK_Views_Posts_PostId" FOREIGN KEY ("PostId") REFERENCES public."Posts"("Id") ON DELETE CASCADE;


--
-- Name: Votes FK_Votes_Messages_MessageId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Votes"
    ADD CONSTRAINT "FK_Votes_Messages_MessageId" FOREIGN KEY ("MessageId") REFERENCES public."Messages"("Id") ON DELETE CASCADE;


--
-- Name: Votes FK_Votes_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: quocanh
--

ALTER TABLE ONLY public."Votes"
    ADD CONSTRAINT "FK_Votes_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

