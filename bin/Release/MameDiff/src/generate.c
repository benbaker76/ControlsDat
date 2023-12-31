/* --------------------------------------------------------------------------
 * MAMEDiff - Written by Logiqx (http://www.logiqx.com/)
 *
 * A simple little utility for comparing different versions of MAME to identify
 * changes required to your ROM sets.
 * -------------------------------------------------------------------------- */

/* --- The standard includes --- */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>


/* --- Dat library includes --- */

#include "datlib/src/datlib.h"
#include "datlib/src/macro.h"


/* --- MAMEDiff definitions and macros --- */

#include "mamediff.h"
#include "generate.h"


/* --- Is DatLib debugging enabled? --- */

extern int datlib_debug;


/* --- Dat generation --- */

int generate_changes(struct dat *dat1, struct dat *dat2, int diff_type, int renames, int zeros, int exclude_removals, int object_type)
{
	FILE *changes_log=0, *changes_dat=0;

	char st[MAX_STRING_LENGTH];

	char *extra;

	struct game_zip *curr_game_zip1, *curr_game_zip2;
	struct game_zip_idx *curr_game_zip_name_idx1, *curr_game_zip_name_idx2;

	struct game_zip_rom *curr_game_zip_rom1, *curr_game_zip_rom2;
	struct game_zip_disk *curr_game_zip_disk1, *curr_game_zip_disk2;
	struct game_zip_sample *curr_game_zip_sample1, *curr_game_zip_sample2;

	struct game *curr_game;
	struct game_idx *curr_game_name_idx;

	struct rom *curr_rom;
	struct disk *curr_disk;
	struct sample *curr_sample;

	uint32_t i, j, k;

	int num_game_zip_removals=0, num_game_zip_additions=0;
	int num_game_zip_rom_removals=0, num_game_zip_rom_additions=0;
	int num_game_zip_disk_removals=0, num_game_zip_disk_additions=0;
	int num_game_zip_sample_removals=0, num_game_zip_sample_additions=0;

	int found, errflg=0;

	/* --- Create the output files --- */

	if (!errflg)
		FOPEN(changes_log, "mamediff.log", "w")

	if (!errflg)
		FOPEN(changes_dat, "mamediff.dat", "w")

	/* --- Search for ZIP and ROM removals --- */

	if (!exclude_removals)
	{
		for (i=0, curr_game_zip1=dat1->game_zips; !errflg && i<dat1->num_game_zips; i++, curr_game_zip1++)
		{
			curr_game_zip_name_idx2=bsearch((void *)curr_game_zip1->game->name, dat2->game_zip_name_idx, dat2->num_game_zips, sizeof(struct game_zip_idx), find_game_zip_by_name);

			if (curr_game_zip_name_idx2)
			{
				curr_game_zip2=curr_game_zip_name_idx2->game_zip;

				/* --- ROMs --- */

				for (j=0, curr_game_zip_rom1=curr_game_zip1->game_zip_roms;
					object_type==OPTION_OBJECT_TYPE_ROM && j<curr_game_zip1->num_game_zip_roms;
					j++, curr_game_zip_rom1++)
				{
					found=0;

					for (k=0, curr_game_zip_rom2=curr_game_zip2->game_zip_roms;
						!found && k<curr_game_zip2->num_game_zip_roms; k++, curr_game_zip_rom2++)
					{
						if ((!strcmp(curr_game_zip_rom2->rom->status, "nodump") ||
							curr_game_zip_rom1->rom->crc==curr_game_zip_rom2->rom->crc ||
							curr_game_zip_rom1->rom->crc==~curr_game_zip_rom2->rom->crc) &&
							curr_game_zip_rom1->rom->size==curr_game_zip_rom2->rom->size &&
							((renames==0 && strcmp(curr_game_zip_rom2->rom->status, "nodump")) ||
							 !strcmp(curr_game_zip_rom1->rom->name, curr_game_zip_rom2->rom->name)))
						{
							found++;
						}
					}

					if (!found)
					{
						if (curr_game_zip2->num_game_zip_roms>0)
						{
							curr_game_zip_rom1->flags|=GAME_ZIP_ROM_REMOVED;
							curr_game_zip1->flags|=GAME_ZIP_ROM_REMOVED;
							num_game_zip_rom_removals++;
						}
						else
						{
							curr_game_zip1->flags|=GAME_ZIP_REMOVED;
							num_game_zip_removals++;
						}
					}
				}

				/* --- Disks --- */

				for (j=0, curr_game_zip_disk1=curr_game_zip1->game_zip_disks;
					object_type==OPTION_OBJECT_TYPE_DISK && j<curr_game_zip1->num_game_zip_disks;
					j++, curr_game_zip_disk1++)
				{
					found=0;

					for (k=0, curr_game_zip_disk2=curr_game_zip2->game_zip_disks;
						!found && k<curr_game_zip2->num_game_zip_disks; k++, curr_game_zip_disk2++)
					{
						if ((!strcmp(curr_game_zip_disk2->disk->status, "nodump") ||
							curr_game_zip_disk1->disk->crc==curr_game_zip_disk2->disk->crc) &&
							((renames==0 && strcmp(curr_game_zip_disk2->disk->status, "nodump")) ||
							 !strcmp(curr_game_zip_disk1->disk->name, curr_game_zip_disk2->disk->name)))
						{
							found++;
						}
					}

					if (!found)
					{
						if (curr_game_zip2->num_game_zip_disks>0)
						{
							curr_game_zip_disk1->flags|=GAME_ZIP_DISK_REMOVED;
							curr_game_zip1->flags|=GAME_ZIP_DISK_REMOVED;
							num_game_zip_disk_removals++;
						}
						else
						{
							curr_game_zip1->flags|=GAME_ZIP_REMOVED;
							num_game_zip_removals++;
						}
					}
				}

				/* --- Samples --- */

				for (j=0, curr_game_zip_sample1=curr_game_zip1->game_zip_samples;
					object_type==OPTION_OBJECT_TYPE_SAMPLE && j<curr_game_zip1->num_game_zip_samples;
					j++, curr_game_zip_sample1++)
				{
					found=0;

					for (k=0, curr_game_zip_sample2=curr_game_zip2->game_zip_samples;
						!found && k<curr_game_zip2->num_game_zip_samples; k++, curr_game_zip_sample2++)
					{
						if (!strcmp(curr_game_zip_sample1->sample->name, curr_game_zip_sample2->sample->name))
						{
							found++;
						}
					}

					if (!found)
					{
						if (curr_game_zip2->num_game_zip_samples>0)
						{
							curr_game_zip_sample1->flags|=GAME_ZIP_SAMPLE_REMOVED;
							curr_game_zip1->flags|=GAME_ZIP_SAMPLE_REMOVED;
							num_game_zip_sample_removals++;
						}
						else
						{
							curr_game_zip1->flags|=GAME_ZIP_REMOVED;
							num_game_zip_removals++;
						}
					}
				}
			}
			else
			{
				if ((object_type==OPTION_OBJECT_TYPE_ROM && curr_game_zip1->num_game_zip_roms>0) ||
					(object_type==OPTION_OBJECT_TYPE_DISK && curr_game_zip1->num_game_zip_disks>0) ||
					(object_type==OPTION_OBJECT_TYPE_SAMPLE && curr_game_zip1->num_game_zip_samples>0))
				{
					curr_game_zip1->flags|=GAME_ZIP_REMOVED;
					num_game_zip_removals++;
				}
			}
		}
	}

	/* --- Search for ZIP and ROM additions --- */

	for (i=0, curr_game_zip2=dat2->game_zips; !errflg && i<dat2->num_game_zips; i++, curr_game_zip2++)
	{
		curr_game_zip_name_idx1=bsearch((void *)curr_game_zip2->game->name, dat1->game_zip_name_idx, dat1->num_game_zips, sizeof(struct game_zip_idx), find_game_zip_by_name);

		if (curr_game_zip_name_idx1)
		{
			curr_game_zip1=curr_game_zip_name_idx1->game_zip;
			curr_game_zip2->flags|=curr_game_zip1->flags;
		}
		else
		{
			curr_game_zip1=0;
		}

		/* --- ROMs --- */

		for (j=0, curr_game_zip_rom2=curr_game_zip2->game_zip_roms;
			object_type==OPTION_OBJECT_TYPE_ROM && j<curr_game_zip2->num_game_zip_roms;
			j++, curr_game_zip_rom2++)
		{
			found=0;

			if (curr_game_zip1)
			{
				for (k=0, curr_game_zip_rom1=curr_game_zip1->game_zip_roms;
					!found && k<curr_game_zip1->num_game_zip_roms; k++, curr_game_zip_rom1++)
				{
					if ((!strcmp(curr_game_zip_rom2->rom->status, "nodump") ||
						curr_game_zip_rom1->rom->crc==curr_game_zip_rom2->rom->crc ||
						curr_game_zip_rom1->rom->crc==~curr_game_zip_rom2->rom->crc) &&
						curr_game_zip_rom1->rom->size==curr_game_zip_rom2->rom->size &&
						((renames==0 && strcmp(curr_game_zip_rom2->rom->status, "nodump")) ||
						 !strcmp(curr_game_zip_rom1->rom->name, curr_game_zip_rom2->rom->name)))
					{
						found++;
					}
				}
			}

			if (!found && diff_type==3)
			{
				curr_game_name_idx=0;

				if (dat2->options->options & OPTION_DAT_FULL_MERGING)
					curr_game_name_idx=bsearch((void *)curr_game_zip_rom2->rom->game->name, dat1->game_name_idx, dat1->num_games, sizeof(struct game_idx), find_game_by_name);
				else if (curr_game_zip_rom2->rom->game->romof)
				{
					curr_game_name_idx=bsearch((void *)curr_game_zip_rom2->rom->game->romof, dat1->game_name_idx, dat1->num_games, sizeof(struct game_idx), find_game_by_name);
				}

				if (curr_game_name_idx)
				{
					curr_game=curr_game_name_idx->game;

					for (k=0, curr_rom=curr_game->roms; !found && k<curr_game->num_roms; k++, curr_rom++)
					{
						if ((!strcmp(curr_game_zip_rom2->rom->status, "nodump") ||
							curr_rom->crc==curr_game_zip_rom2->rom->crc ||
							curr_rom->crc==~curr_game_zip_rom2->rom->crc) &&
							curr_rom->size==curr_game_zip_rom2->rom->size &&
							((renames==0 && strcmp(curr_game_zip_rom2->rom->status, "nodump")) ||
							!strcmp(curr_rom->name, curr_game_zip_rom2->rom->name)))
						{
							found++;
						}
					}

					if (found)
					{
						curr_game_zip_rom2->flags|=GAME_ZIP_ROM_ELSEWHERE;
						curr_game_zip2->flags|=GAME_ZIP_ROM_ELSEWHERE;
					}
				}
			}

			if (!found && diff_type==4 && strcmp(curr_game_zip_rom2->rom->status, "nodump"))
			{
				if (bsearch((const void *)&curr_game_zip_rom2->rom->crc,
					dat1->rom_crc_idx, dat1->num_roms, sizeof(struct rom_idx), find_rom_by_crc) ||
				bsearch((const void *)&curr_game_zip_rom2->rom->crc,
					dat1->rom_crc_idx, dat1->num_roms, sizeof(struct rom_idx), find_rom_by_comp_crc))
				{
					found++;

					curr_game_zip_rom2->flags|=GAME_ZIP_ROM_ELSEWHERE;
					curr_game_zip2->flags|=GAME_ZIP_ROM_ELSEWHERE;
				}
			}

			if (!found)
			{
				if (curr_game_zip1 && curr_game_zip1->num_game_zip_roms>0)
				{
					curr_game_zip_rom2->flags|=GAME_ZIP_ROM_ADDED;
					curr_game_zip2->flags|=GAME_ZIP_ROM_ADDED;
					num_game_zip_rom_additions++;
				}
				else
				{
					curr_game_zip2->flags|=GAME_ZIP_ADDED;
					num_game_zip_additions++;
				}
			}
		}

		/* --- Disks --- */

		for (j=0, curr_game_zip_disk2=curr_game_zip2->game_zip_disks;
			object_type==OPTION_OBJECT_TYPE_DISK && j<curr_game_zip2->num_game_zip_disks;
			j++, curr_game_zip_disk2++)
		{
			found=0;

			if (curr_game_zip1)
			{
				for (k=0, curr_game_zip_disk1=curr_game_zip1->game_zip_disks;
					!found && k<curr_game_zip1->num_game_zip_disks; k++, curr_game_zip_disk1++)
				{
					if ((!strcmp(curr_game_zip_disk2->disk->status, "nodump") ||
						curr_game_zip_disk1->disk->crc==curr_game_zip_disk2->disk->crc) &&
						((renames==0 && strcmp(curr_game_zip_disk2->disk->status, "nodump")) ||
						 !strcmp(curr_game_zip_disk1->disk->name, curr_game_zip_disk2->disk->name)))
					{
						found++;
					}
				}
			}

			if (!found && diff_type==3)
			{
				curr_game_name_idx=0;

				if (dat2->options->options & OPTION_DAT_FULL_MERGING)
					curr_game_name_idx=bsearch((void *)curr_game_zip_disk2->disk->game->name, dat1->game_name_idx, dat1->num_games, sizeof(struct game_idx), find_game_by_name);
				else if (curr_game_zip_disk2->disk->game->romof)
				{
					curr_game_name_idx=bsearch((void *)curr_game_zip_disk2->disk->game->romof, dat1->game_name_idx, dat1->num_games, sizeof(struct game_idx), find_game_by_name);
				}

				if (curr_game_name_idx)
				{
					curr_game=curr_game_name_idx->game;

					for (k=0, curr_disk=curr_game->disks; !found && k<curr_game->num_disks; k++, curr_disk++)
					{
						if ((!strcmp(curr_game_zip_disk2->disk->status, "nodump") ||
							curr_disk->crc==curr_game_zip_disk2->disk->crc) &&
							((renames==0 && strcmp(curr_game_zip_disk2->disk->status, "nodump")) ||
							!strcmp(curr_disk->name, curr_game_zip_disk2->disk->name)))
						{
							found++;
						}
					}

					if (found)
					{
						curr_game_zip_disk2->flags|=GAME_ZIP_DISK_ELSEWHERE;
						curr_game_zip2->flags|=GAME_ZIP_DISK_ELSEWHERE;
					}
				}
			}

			if (!found && diff_type==4 && strcmp(curr_game_zip_disk2->disk->status, "nodump"))
			{
				if (bsearch((const void *)&curr_game_zip_disk2->disk->crc,
					dat1->disk_crc_idx, dat1->num_disks, sizeof(struct disk_idx), find_disk_by_crc))
				{
					found++;

					curr_game_zip_disk2->flags|=GAME_ZIP_ROM_ELSEWHERE;
					curr_game_zip2->flags|=GAME_ZIP_ROM_ELSEWHERE;
				}
			}

			if (!found)
			{
				if (curr_game_zip1 && curr_game_zip1->num_game_zip_disks>0)
				{
					curr_game_zip_disk2->flags|=GAME_ZIP_DISK_ADDED;
					curr_game_zip2->flags|=GAME_ZIP_DISK_ADDED;
					num_game_zip_disk_additions++;
				}
				else
				{
					curr_game_zip2->flags|=GAME_ZIP_ADDED;
					num_game_zip_additions++;
				}
			}
		}

		/* --- Samples --- */

		for (j=0, curr_game_zip_sample2=curr_game_zip2->game_zip_samples;
			object_type==OPTION_OBJECT_TYPE_SAMPLE && j<curr_game_zip2->num_game_zip_samples;
			j++, curr_game_zip_sample2++)
		{
			found=0;

			if (curr_game_zip1)
			{
				for (k=0, curr_game_zip_sample1=curr_game_zip1->game_zip_samples;
					!found && k<curr_game_zip1->num_game_zip_samples; k++, curr_game_zip_sample1++)
				{
					if (!strcmp(curr_game_zip_sample1->sample->name, curr_game_zip_sample2->sample->name))
					{
						found++;
					}
				}
			}

			if (!found && diff_type>=3)	// Cannot do a CRC search for diff_type 4 (as with roms and disks)
			{
				curr_game_name_idx=0;

				if (dat2->options->options & OPTION_DAT_FULL_MERGING)
					curr_game_name_idx=bsearch((void *)curr_game_zip_sample2->sample->game->name, dat1->game_name_idx, dat1->num_games, sizeof(struct game_idx), find_game_by_name);
				else if (curr_game_zip_sample2->sample->game->sampleof)
				{
					curr_game_name_idx=bsearch((void *)curr_game_zip_sample2->sample->game->sampleof, dat1->game_name_idx, dat1->num_games, sizeof(struct game_idx), find_game_by_name);
				}

				if (curr_game_name_idx)
				{
					curr_game=curr_game_name_idx->game;

					for (k=0, curr_sample=curr_game->samples; !found && k<curr_game->num_samples; k++, curr_sample++)
					{
						if (!strcmp(curr_sample->name, curr_game_zip_sample2->sample->name))
						{
							found++;
						}
					}

					if (found)
					{
						curr_game_zip_sample2->flags|=GAME_ZIP_SAMPLE_ELSEWHERE;
						curr_game_zip2->flags|=GAME_ZIP_SAMPLE_ELSEWHERE;
					}
				}
			}

			if (!found)
			{
				if (curr_game_zip1 && curr_game_zip1->num_game_zip_samples>0)
				{
					curr_game_zip_sample2->flags|=GAME_ZIP_SAMPLE_ADDED;
					curr_game_zip2->flags|=GAME_ZIP_SAMPLE_ADDED;
					num_game_zip_sample_additions++;
				}
				else
				{
					curr_game_zip2->flags|=GAME_ZIP_ADDED;
					num_game_zip_additions++;
				}
			}
		}
	}

	/* --- Generate Log --- */

	if (!errflg && diff_type==1)
	{
		if (num_game_zip_removals || num_game_zip_additions ||
			num_game_zip_rom_removals || num_game_zip_rom_additions ||
			num_game_zip_disk_removals || num_game_zip_disk_additions ||
			num_game_zip_sample_removals || num_game_zip_sample_additions)
		{
			strcpy(st, dat2->name);
			if (strstr(st, ".dat")) *strstr(st, ".dat")=0;
			if (!exclude_removals)
			{
				fprintf(changes_log, "Changes dat for use with %s\n", st);

				fprintf(changes_log, "Copy changes over a perfect ");
			}
			else
			{
				fprintf(changes_log, "Supplementary dat for use with %s\n", st);

				fprintf(changes_log, "Use in addition to a perfect ");
			}
			if (dat1->options->options & OPTION_DAT_NO_MERGING)
				fprintf(changes_log, "non-merged");
			if (dat1->options->options & OPTION_DAT_SPLIT_MERGING)
				fprintf(changes_log, "split-merged");
			if (dat1->options->options & OPTION_DAT_FULL_MERGING)
				fprintf(changes_log, "fully-merged");

			strcpy(st, dat1->name);
			if (strstr(st, ".dat")) *strstr(st, ".dat")=0;
			if (strchr(st, '/')) strcpy(st, strrchr(st, '/')+1);
			if (strchr(st, '\\')) strcpy(st, strrchr(st, '\\')+1);
			fprintf(changes_log, " set for %s\n\n", st);

			fprintf(changes_log, "Created using MAMEDiff %s with option(s): -d%d ", MAMEDIFF_VERSION, diff_type);

			if (object_type==OPTION_OBJECT_TYPE_DISK)
				fprintf(changes_log, "-o disk ");
			else if (object_type==OPTION_OBJECT_TYPE_SAMPLE)
				fprintf(changes_log, "-o sample ");

			if (exclude_removals)
				fprintf(changes_log, "-x ");

			if (renames)
				fprintf(changes_log, "-r ");

			if (zeros)
				fprintf(changes_log, "-z ");

			if (dat1->options->options & OPTION_NON_SEPERATED_BIOS_ROMS)
				fprintf(changes_log, "-b ");

			fprintf(changes_log, "\n\n");

			/* --- Report ZIP removals --- */

			if (!exclude_removals)
			{
				if (object_type==OPTION_OBJECT_TYPE_DISK)
				{
					if (dat2->options->options & OPTION_DAT_FULL_MERGING)
						LRPAD(st, " Directories Removed (n.b. directories include clones) ", "-", 80)
					else
						LRPAD(st, " Directories Removed ", "-", 80)
				}
				else
				{
					if (dat2->options->options & OPTION_DAT_FULL_MERGING)
						LRPAD(st, " ZIPs Removed (n.b. ZIPs include clones) ", "-", 80)
					else
						LRPAD(st, " ZIPs Removed ", "-", 80)
				}
				fprintf(changes_log, "%s\n\n", st);
				for (j=i=0, curr_game_zip_name_idx1=dat1->game_zip_name_idx; i<dat1->num_game_zips; i++, curr_game_zip_name_idx1++)
				{
					curr_game_zip1=curr_game_zip_name_idx1->game_zip;

					if (curr_game_zip1->flags & GAME_ZIP_REMOVED)
					{
						if (object_type==OPTION_OBJECT_TYPE_DISK)
							fprintf(changes_log, "%8s - %s\n", curr_game_zip1->game->name, curr_game_zip1->game->description);
						else
							fprintf(changes_log, "%8s.zip - %s\n", curr_game_zip1->game->name, curr_game_zip1->game->description);
						j++;
					}
				}
				if (object_type==OPTION_OBJECT_TYPE_DISK)
				{
					if (!j) fprintf(changes_log, "No directories removed.\n");
				}
				else
				{
					if (!j) fprintf(changes_log, "No ZIPs removed.\n");
				}
				fprintf(changes_log, "\n");
			}

			/* --- Report ZIP changes --- */

			if (object_type==OPTION_OBJECT_TYPE_DISK)
			{
				if (dat2->options->options & OPTION_DAT_FULL_MERGING)
					LRPAD(st, " Directories Changed (n.b. directories include clones) ", "-", 80)
				else
					LRPAD(st, " Directories Changed ", "-", 80)
			}
			else
			{
				if (dat2->options->options & OPTION_DAT_FULL_MERGING)
					LRPAD(st, " ZIPs Changed (n.b. ZIPs include clones) ", "-", 80)
				else
					LRPAD(st, " ZIPs Changed ", "-", 80)
			}
			fprintf(changes_log, "%s\n\n", st);
			for (j=i=0, curr_game_zip_name_idx2=dat2->game_zip_name_idx; i<dat2->num_game_zips; i++, curr_game_zip_name_idx2++)
			{
				curr_game_zip2=curr_game_zip_name_idx2->game_zip;

				if (curr_game_zip2->flags & (GAME_ZIP_ROM_REMOVED | GAME_ZIP_ROM_ADDED | GAME_ZIP_DISK_REMOVED | GAME_ZIP_DISK_ADDED | GAME_ZIP_SAMPLE_REMOVED | GAME_ZIP_SAMPLE_ADDED))
				{
					if (object_type==OPTION_OBJECT_TYPE_DISK)
						fprintf(changes_log, "%8s - %s\n", curr_game_zip2->game->name, curr_game_zip2->game->description);
					else
						fprintf(changes_log, "%8s.zip - %s\n", curr_game_zip2->game->name, curr_game_zip2->game->description);
					j++;
				}
			}
			if (object_type==OPTION_OBJECT_TYPE_DISK)
			{
				if (!j) fprintf(changes_log, "No directories changed.\n");
			}
			else
			{
				if (!j) fprintf(changes_log, "No ZIPs changed.\n");
			}
			fprintf(changes_log, "\n");

			/* --- Report ZIP additions --- */

			if (object_type==OPTION_OBJECT_TYPE_DISK)
			{
				if (dat2->options->options & OPTION_DAT_FULL_MERGING)
					LRPAD(st, " Directories Added (n.b. directories include clones) ", "-", 80)
				else
					LRPAD(st, " Directories Added ", "-", 80)
			}
			else
			{
				if (dat2->options->options & OPTION_DAT_FULL_MERGING)
					LRPAD(st, " ZIPs Added (n.b. ZIPs include clones) ", "-", 80)
				else
					LRPAD(st, " ZIPs Added ", "-", 80)
			}
			fprintf(changes_log, "%s\n\n", st);
			for (j=i=0, curr_game_zip_name_idx2=dat2->game_zip_name_idx; i<dat2->num_game_zips; i++, curr_game_zip_name_idx2++)
			{
				curr_game_zip2=curr_game_zip_name_idx2->game_zip;

				if (curr_game_zip2->flags & GAME_ZIP_ADDED)
				{
					if (object_type==OPTION_OBJECT_TYPE_DISK)
						fprintf(changes_log, "%8s - %s\n", curr_game_zip2->game->name, curr_game_zip2->game->description);
					else
						fprintf(changes_log, "%8s.zip - %s\n", curr_game_zip2->game->name, curr_game_zip2->game->description);
					j++;
				}
			}
			if (object_type==OPTION_OBJECT_TYPE_DISK)
			{
				if (!j) fprintf(changes_log, "No directories added.\n");
			}
			else
			{
				if (!j) fprintf(changes_log, "No ZIPs added.\n");
			}
			fprintf(changes_log, "\n");
		}
	}

	if (!errflg && diff_type>1)
	{
		if (num_game_zip_additions ||
			num_game_zip_rom_additions || num_game_zip_disk_additions || num_game_zip_sample_additions)
		{
			strcpy(st, dat2->name);
			if (strstr(st, ".dat")) *strstr(st, ".dat")=0;

			if (diff_type<4)
			{
				fprintf(changes_log, "Supplementary dat for use with %s\n", st);

				fprintf(changes_log, "Use in addition to a perfect ");
				if (dat1->options->options & OPTION_DAT_NO_MERGING)
					fprintf(changes_log, "non-merged");
				if (dat1->options->options & OPTION_DAT_SPLIT_MERGING)
					fprintf(changes_log, "split-merged");
				if (dat1->options->options & OPTION_DAT_FULL_MERGING)
					fprintf(changes_log, "fully-merged");
			}
			else
			{
				fprintf(changes_log, "Archival dat for use with %s\n", st);

				fprintf(changes_log, "When rebuilding, use in addition to a complete");
			}

			strcpy(st, dat1->name);
			if (strstr(st, ".dat")) *strstr(st, ".dat")=0;
			if (strchr(st, '/')) strcpy(st, strrchr(st, '/')+1);
			if (strchr(st, '\\')) strcpy(st, strrchr(st, '\\')+1);
			fprintf(changes_log, " set for %s\n\n", st);

			fprintf(changes_log, "Created using MAMEDiff %s with option(s): -d%d ", MAMEDIFF_VERSION, diff_type);

			if (object_type==OPTION_OBJECT_TYPE_DISK)
				fprintf(changes_log, "-o disk ");
			else if (object_type==OPTION_OBJECT_TYPE_SAMPLE)
				fprintf(changes_log, "-o sample ");

			if (exclude_removals)
				fprintf(changes_log, "-x ");

			if (renames)
				fprintf(changes_log, "-r ");

			if (zeros)
				fprintf(changes_log, "-z ");

			if (dat1->options->options & OPTION_NON_SEPERATED_BIOS_ROMS)
				fprintf(changes_log, "-b ");

			fprintf(changes_log, "\n\n");

			for (i=0, curr_game_zip2=dat2->game_zips; i<dat2->num_game_zips; i++, curr_game_zip2++)
			{
				if ((curr_game_zip2->flags & (GAME_ZIP_ADDED|GAME_ZIP_ROM_ADDED|GAME_ZIP_DISK_ADDED|GAME_ZIP_SAMPLE_ADDED)))
				{
					curr_game=curr_game_zip2->game;

					/* --- Break link to parent as changes dats do not use merging --- */

					curr_game->cloneof=0;
					curr_game->game_flags&=~FLAG_GAME_CLONEOF;

					curr_game->romof=0;
					curr_game->game_flags&=~FLAG_GAME_ROMOF;

					FORMAT_GAME_NAME(st, curr_game);
					if (object_type==OPTION_OBJECT_TYPE_DISK && curr_game->sourcefile!=0 && !strcmp(curr_game->sourcefile, "cps2.c"))
						extra = "CPS-2: ";
					else
						extra = "";
					fprintf(changes_log, "%s%s\n\n", extra, st);

					/* --- ROMs --- */

					for (j=0, curr_game_zip_rom2=curr_game_zip2->game_zip_roms;
						object_type==OPTION_OBJECT_TYPE_ROM && j<curr_game_zip2->num_game_zip_roms;
						j++, curr_game_zip_rom2++)
					{
						curr_rom=curr_game_zip_rom2->rom;

						if ((curr_game_zip2->flags & GAME_ZIP_ADDED &&
							!(diff_type>=3 && curr_game_zip_rom2->flags & GAME_ZIP_ROM_ELSEWHERE)) ||
							curr_game_zip_rom2->flags & GAME_ZIP_ROM_ADDED)
						{
							if (!strcmp(curr_rom->status, "nodump"))
								fprintf(changes_log, "  ROM: %12s (%7lu bytes, no dump available)", curr_rom->name, (unsigned long) curr_rom->size);
							else
								fprintf(changes_log, "  ROM: %12s (%7lu bytes, crc %08lx)", curr_rom->name, (unsigned long) curr_rom->size, (unsigned long) curr_rom->crc);

							if (dat2->options->options & OPTION_DAT_FULL_MERGING)
								fprintf(changes_log, " - from %s", curr_rom->game->name);

							fprintf(changes_log, "\n");
						}
					}

					/* --- Disks --- */

					for (j=0, curr_game_zip_disk2=curr_game_zip2->game_zip_disks;
						object_type==OPTION_OBJECT_TYPE_DISK && j<curr_game_zip2->num_game_zip_disks;
						j++, curr_game_zip_disk2++)
					{
						curr_disk=curr_game_zip_disk2->disk;

						if ((curr_game_zip2->flags & GAME_ZIP_ADDED &&
							!(diff_type>=3 && curr_game_zip_disk2->flags & GAME_ZIP_DISK_ELSEWHERE)) ||
							curr_game_zip_disk2->flags & GAME_ZIP_DISK_ADDED)
						{
							if (!strcmp(curr_disk->status, "nodump"))
								fprintf(changes_log, "  Disk: %12s (no dump available)", curr_disk->name);
							else
							{
								if (dat1->options->options & OPTION_MD5_CHECKSUMS)
									fprintf(changes_log, "  Disk: %12s (md5 %s)", curr_disk->name, curr_disk->md5);
								else
									fprintf(changes_log, "  Disk: %12s (sha1 %s)", curr_disk->name, curr_disk->sha1);
							}

							if (dat2->options->options & OPTION_DAT_FULL_MERGING)
								fprintf(changes_log, " - from %s", curr_disk->game->name);

							fprintf(changes_log, "\n");
						}
					}

					/* --- Samples --- */

					for (j=0, curr_game_zip_sample2=curr_game_zip2->game_zip_samples;
						object_type==OPTION_OBJECT_TYPE_SAMPLE && j<curr_game_zip2->num_game_zip_samples;
						j++, curr_game_zip_sample2++)
					{
						curr_sample=curr_game_zip_sample2->sample;

						if ((curr_game_zip2->flags & GAME_ZIP_ADDED &&
							!(diff_type>=3 && curr_game_zip_sample2->flags & GAME_ZIP_SAMPLE_ELSEWHERE)) ||
							curr_game_zip_sample2->flags & GAME_ZIP_SAMPLE_ADDED)
						{
							fprintf(changes_log, "  Sample: %12s", curr_sample->name);

							if (dat2->options->options & OPTION_DAT_FULL_MERGING)
								fprintf(changes_log, " - from %s", curr_sample->game->name);

							fprintf(changes_log, "\n");
						}
					}

					fprintf(changes_log, "\n");
				}
			}
		}
	}

	/* --- Generate Dat --- */

	if (!errflg)
	{
		for (i=0, curr_game_zip2=dat2->game_zips; i<dat2->num_game_zips; i++, curr_game_zip2++)
		{
			if ((curr_game_zip2->flags & (GAME_ZIP_ADDED|GAME_ZIP_ROM_ADDED|GAME_ZIP_DISK_ADDED|GAME_ZIP_SAMPLE_ADDED)) ||
				(diff_type==1 && curr_game_zip2->flags & (GAME_ZIP_ROM_REMOVED|GAME_ZIP_DISK_REMOVED|GAME_ZIP_SAMPLE_REMOVED)))
			{
				curr_game=curr_game_zip2->game;

				//fprintf(changes_dat, "// Flags for %s within generate.c of MAMEDiff=%08lx\n\n", curr_game->name, (unsigned long)curr_game_zip2->flags);

				fprintf(changes_dat, "game (\n");

				if (strchr(curr_game->name, ' '))
					fprintf(changes_dat, "\tname \"%s\"\n", curr_game->name);
				else
					fprintf(changes_dat, "\tname %s\n", curr_game->name);

				if (object_type==OPTION_OBJECT_TYPE_DISK && curr_game->sourcefile!=0 && !strcmp(curr_game->sourcefile, "cps2.c"))
					extra="CPS-2: ";
				else
					extra="";

				if (curr_game->description!=0)
				{
					if (dat2->options->options & OPTION_DAT_FULL_MERGING)
						fprintf(changes_dat, "\tdescription \"%s%s [n.b. includes clones]\"\n", extra, curr_game->description);
					else
						fprintf(changes_dat, "\tdescription \"%s%s\"\n", extra, curr_game->description);
				}

				if (curr_game->year!=0)
				{
					if (strchr(curr_game->year, ' '))
						fprintf(changes_dat, "\tyear \"%s\"\n", curr_game->year);
					else
						fprintf(changes_dat, "\tyear %s\n", curr_game->year);
				}

				if (curr_game->manufacturer!=0)
					fprintf(changes_dat, "\tmanufacturer \"%s\"\n", curr_game->manufacturer);

				if (curr_game->sourcefile!=0)
					fprintf(changes_dat, "\tsourcefile %s\n", curr_game->sourcefile);

				for (j=0, curr_game_zip_rom2=curr_game_zip2->game_zip_roms;
					object_type==OPTION_OBJECT_TYPE_ROM && j<curr_game_zip2->num_game_zip_roms;
					j++, curr_game_zip_rom2++)
				{
					curr_rom=curr_game_zip_rom2->rom;

					if (diff_type==1 ||
						(curr_game_zip2->flags & GAME_ZIP_ADDED &&
						!(diff_type>=3 && curr_game_zip_rom2->flags & GAME_ZIP_ROM_ELSEWHERE)) ||
						curr_game_zip_rom2->flags & GAME_ZIP_ROM_ADDED)
					{
						curr_rom->merge=0;
						curr_rom->rom_flags&=~FLAG_ROM_MERGE;

						FORMAT_LISTINFO_ROM(st, curr_rom)

						fprintf(changes_dat, "\t%s\n", st);
					}
				}

				for (j=0, curr_game_zip_disk2=curr_game_zip2->game_zip_disks;
					object_type==OPTION_OBJECT_TYPE_DISK && j<curr_game_zip2->num_game_zip_disks;
					j++, curr_game_zip_disk2++)
				{
					curr_disk=curr_game_zip_disk2->disk;

					if (diff_type==1 ||
						(curr_game_zip2->flags & GAME_ZIP_ADDED &&
						!(diff_type>=3 && curr_game_zip_disk2->flags & GAME_ZIP_DISK_ELSEWHERE)) ||
						curr_game_zip_disk2->flags & GAME_ZIP_DISK_ADDED)
					{
						curr_disk->merge=0;
						curr_disk->disk_flags&=~FLAG_DISK_MERGE;

						FORMAT_LISTINFO_DISK(st, curr_disk)

						fprintf(changes_dat, "\t%s\n", st);
					}
				}

				for (j=0, curr_game_zip_sample2=curr_game_zip2->game_zip_samples;
					object_type==OPTION_OBJECT_TYPE_SAMPLE && j<curr_game_zip2->num_game_zip_samples;
					j++, curr_game_zip_sample2++)
				{
					curr_sample=curr_game_zip_sample2->sample;

					if (diff_type==1 ||
						(curr_game_zip2->flags & GAME_ZIP_ADDED &&
						!(diff_type>=3 && curr_game_zip_sample2->flags & GAME_ZIP_SAMPLE_ELSEWHERE)) ||
						curr_game_zip_sample2->flags & GAME_ZIP_SAMPLE_ADDED)
					{
						curr_sample->merge=0;
						// No such flag! curr_sample->sample_flags&=~FLAG_SAMPLE_MERGE;

						FORMAT_LISTINFO_SAMPLE(st, curr_sample)

						fprintf(changes_dat, "\t%s\n", st);
					}
				}

				fprintf(changes_dat, ")\n\n");
			}
		}
	}

	if (!errflg)
	{
		if (num_game_zip_additions || num_game_zip_rom_additions || num_game_zip_disk_additions || num_game_zip_disk_additions ||
			(diff_type==1 && (num_game_zip_rom_removals || num_game_zip_disk_removals || num_game_zip_sample_removals)))
		{
			printf("Report has been written to mamediff.log and dat saved as mamediff.dat\n");
		}
		else
		{
			printf("No supplement required.\n");
			fprintf(changes_log, "No supplement required\n");
		}
	}

	/* --- Close output files --- */

	FCLOSE(changes_dat)
	FCLOSE(changes_log)

	return(errflg);
}
